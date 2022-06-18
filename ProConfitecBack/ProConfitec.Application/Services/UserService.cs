using AutoMapper;
using ProConfitec.Application.DTOs;
using ProConfitec.Application.DTOs.Validations;
using ProConfitec.Application.Services.Interfaces;
using ProConfitec.Domain.Entities;
using ProConfitec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISchoolRecordRepository _schoolRecordsRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public UserService
        (
            IUserRepository userRepository,
            ISchoolRecordRepository schoolRecordsRepository,
            IFileRepository fileRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _schoolRecordsRepository = schoolRecordsRepository;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UserDTO>> CreateAsync(UserDetailDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return ResultService.Fail<UserDTO>("Objeto deve ser informado");

                var result = new UserDatailDTOValidator().Validate(userDTO);
                if (!result.IsValid)
                    return ResultService.RequestError<UserDTO>("Problemas na validação", result);

                var record = new SchoolRecords(userDTO.SchoolRecordsName, userDTO.SchoolRecordsType);
                int idRecord = _schoolRecordsRepository.CreateRecordAsync(record).Result.Id;
                userDTO.SchoolRecordsId = idRecord;

                var saveFile = _fileRepository.AddImage(userDTO.fileSource, idRecord, userDTO.SchoolRecordsName, userDTO.SchoolRecordsType);

                var user = _mapper.Map<User>(userDTO);

                var data = await _userRepository.CreatAsync(user);
                return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
            }
            catch(Exception ex)
            {
                return ResultService.Fail<UserDTO>(ex.Message);
            }

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return ResultService.Fail<UserDTO>("Registro não encontrado");                
            
            int id_record = user.SchoolRecordsId;
            await _userRepository.DeleteAsync(user);            

            var schoolRecord = await _schoolRecordsRepository.GetByIdAsync(id_record);
            await _schoolRecordsRepository.DeleteRecordAsync(schoolRecord);

            return ResultService.Ok($"Registro com id {id} deletado com sucesso");
        }

        public async Task<ResultService<ICollection<UserDetailDTO>>> GetAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return ResultService.Ok<ICollection<UserDetailDTO>>(_mapper.Map<ICollection<UserDetailDTO>>(users));
        }

        public async Task<ResultService<UserDetailDTO>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return ResultService.Fail<UserDetailDTO>("Registro não encontrado");

            return ResultService.Ok<UserDetailDTO>(_mapper.Map<UserDetailDTO>(user));
        }


        public async Task<ResultService> UpdateAsync(UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return ResultService.Fail("Objeto deve ser informado");

                var validation = new UserDTOValidator().Validate(userDTO);
                if (!validation.IsValid)
                    return ResultService.RequestError("Probremas com a validãção do objeto", validation);

                var user = await _userRepository.GetByIdAsync(userDTO.Id);
                if (user == null)
                    return ResultService.Fail("Registro não encontrado");

                user = _mapper.Map<UserDTO, User>(userDTO, user);

                await _userRepository.EditAsync(user);

                return ResultService.Ok("Registro Editado com sucesso !!!");
            }
            catch (Exception ex)
            {

                return ResultService.Fail<UserDTO>(ex.Message);
            }


        }

    }

}
