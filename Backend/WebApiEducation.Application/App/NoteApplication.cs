using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Entity;
using WebApiEducation.Domain.Interface;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Application.App
{
    public class NoteApplication
    {
        private readonly INoteRepository _NoteRepository;
        private IMapper _mapper;

       public NoteApplication (INoteRepository noteRepository, IMapper mapper)
        {
            _NoteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<ResponseServiceDTO> AddNote(NoteDTO note)
        {
            Note request = _mapper.Map<NoteDTO, Note>(note);
            ResponseService response = await _NoteRepository.AddNote(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }

        public async Task<ResponseServiceDTO> DeleteNote(int id) {
            ResponseService response = await _NoteRepository.DeleteNote(id);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }

        public async Task<List<NoteDTO>> GetAll()
        {
            List<Note> response = await _NoteRepository.GetAll();
            return _mapper.Map<List<Note>, List<NoteDTO>>(response);
        }

        public async Task<NoteDTO> GetById(int id)
        { 
            Note response  = await _NoteRepository.GetById(id);
            return _mapper.Map<Note, NoteDTO>(response);
        }
        public async Task<ResponseServiceDTO> UpdateNote(NoteDTO note)
        {
            Note request = _mapper.Map<NoteDTO, Note>(note);
            ResponseService response = await _NoteRepository.UpdateNote(request);
            return _mapper.Map<ResponseService, ResponseServiceDTO>(response);
        }
    }
}
