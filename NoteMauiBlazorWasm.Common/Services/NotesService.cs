using NoteMauiBlazorWasm.Common;
using NoteMauiBlazorWasm.Common.Interfaces;
using NoteMauiBlazorWasm.Common.Models;
using System.Text.Json;

namespace NoteMauiBlazorWasm.Web.Services
{
    //This should go to a database not locally so edit this
    public class NotesService
    {
        private readonly IStorageService _storageService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public NotesService(IStorageService storageService)
        {
            _storageService = storageService;
            _jsonSerializerOptions = new();
        }
        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            var serializedNotes = await _storageService.GetAsync(AppConstants.StorageKeys.Notes);
            if(!string.IsNullOrWhiteSpace(serializedNotes))
            {
                var notes = JsonSerializer.Deserialize<IEnumerable<Note>>(serializedNotes, _jsonSerializerOptions);
                return notes;
            }
            return Enumerable.Empty<Note>();
        }

        public async Task AddNote(Note note)
        {
            if(note.Id == Guid.Empty)
            {
                note.Id = Guid.NewGuid();
                note.CreatedOn = DateTime.Now;
                var notes = (await GetAllNotesAsync()).ToList();

                notes.Add(note);

                await SaveNotesAsync(notes);
            }
        }

        public async Task UpdateNoteAsync(Note note)
        {
            if(note.Id != Guid.Empty)
            {
                var notes = await GetAllNotesAsync();
                var noteToUpdate = notes.FirstOrDefault(n=> n.Id == note.Id);

                if(noteToUpdate is not null)
                {
                    noteToUpdate.Title = note.Title;
                    noteToUpdate.Description = note.Description;
                    note.ModifiedOn = DateTime.Now;

                    await SaveNotesAsync(notes);
                }
            }
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            if(id != Guid.Empty)
            {
                var notes = (await GetAllNotesAsync()).ToList();
                var noteToDelete = notes.FirstOrDefault(n => n.Id == id);

                if(noteToDelete is not null)
                {
                    notes.Remove(noteToDelete);

                    await SaveNotesAsync(notes);
                }

            }
        }

        public async Task<Note?> GetNoteAsync(Guid id)
        {
            if(id != Guid.Empty)
            {
                var notes = await GetAllNotesAsync();
                return notes.FirstOrDefault(n => n.Id == id);
            }
            return null;
        }

        private async Task SaveNotesAsync(IEnumerable<Note> notes)
        {

            var serializedNotes = JsonSerializer.Serialize(notes, _jsonSerializerOptions);
            _storageService.SaveAsync(AppConstants.StorageKeys.Notes, serializedNotes);
        }
    }
}
