using AbbysTowerAPI.Context;
using AbbysTowerAPI.Services.Interfaces;
using Domain.Entities;
using Domain.Helpers;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AbbysTowerAPI.Services.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ApplicationDbContext _context;
        public CharacterServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtener todos los personajes
        public async Task<Response<List<Characters>>> GetAllCharacters()
        {
            try
            {
                List<Characters> response = await _context.Characters.ToListAsync();
                return new Response<List<Characters>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los personajes: {ex.Message}");
            }
        }

        //Obtener un personaje por su ID
        public async Task<Response<Characters>> CharacterById(int id)
        {
            try
            {
                Characters result = await _context.Characters.FirstOrDefaultAsync(x => x.idCharacter == id);
                return new Response<Characters>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Crear personaje
        public async Task<Response<Characters>> CreateCharacter(Characters request)
        {
            try
            {
                Characters newCharacter = new Characters();
                {
                    newCharacter.Nombre = request.Nombre;
                    newCharacter.Descripcion = request.Descripcion;
                    newCharacter.Vida = request.Vida;
                    newCharacter.Ataque = request.Ataque;
                    newCharacter.Defensa = request.Defensa;
                    newCharacter.Imagen = request.Imagen;
                };
                var result = await _context.Characters.AddAsync(newCharacter);
                _context.SaveChanges();
                
                return new Response<Characters>(newCharacter, "El personaje fue creado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el personaje: {ex.Message}");
            }
        }

        //Actualizar personaje
        public async Task<Response<Characters>> UpdateCharacter(int id, Characters request)
        {
            try
            {
                Characters result = await _context.Characters.FirstOrDefaultAsync(x => x.idCharacter == id);
                if (result == null)
                {
                    throw new Exception("El personaje no fue encontrado");
                }

                result.Nombre = request.Nombre;
                result.Descripcion = request.Descripcion;
                result.Vida = request.Vida;
                result.Ataque = request.Ataque;
                result.Defensa = request.Defensa;
                result.Imagen = request.Imagen;
                _context.Characters.Update(result);
                _context.SaveChanges();

                return new Response<Characters>(result, "El personaje fue actualizado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el personaje: {ex.Message}");
            }
        }

        //Eliminar personaje
        public async Task<Response<Characters>> DeleteCharacter(int id)
        {
            try
            {
                Characters result = await _context.Characters.FirstOrDefaultAsync(x => x.idCharacter == id);
                if (result == null)
                {
                    throw new Exception("El personaje no fue encontrado");
                }
                _context.Characters.Remove(result);
                _context.SaveChanges();
                return new Response<Characters>(result, "El personaje fue eliminado exitosamente");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el personaje: {ex.Message}");
            }
        }
    }
}
