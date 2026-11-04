using System.Data;
using AbbysTowerAPI.Context;
using AbbysTowerAPI.Services.Interfaces;
using Domain.Entities;
using Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AbbysTowerAPI.Services.Services
{
    public class LevelServices: ILevelServices
    {
        private readonly ApplicationDbContext _context;
        public LevelServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Obtener niveles
        public async Task<Response<List<Levels>>> GetAllLevels()
        {
            try
            {
                List<Levels> response = await _context.Levels.ToListAsync();
                return new Response<List<Levels>>(response.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        //Obtener niveles por id

        public async Task<Response<Levels>> GetLevelById(int id)
        {
            try
            {
                Levels response = await _context.Levels.FirstOrDefaultAsync(x => x.idLevel == id);
                if (response == null)
                {
                    return new Response<Levels>("No se encontro el nivel");
                }
                return new Response<Levels>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        //Crear niveles
        public async Task<Response<Levels>> CreateLevel(Levels request)
        {
            try
            {
                Levels newLevel = new Levels();
                {
                    newLevel.Nombre = request.Nombre;
                    newLevel.descripcion = request.descripcion;
                }

                var result = await _context.Levels.AddAsync(newLevel);
                _context.SaveChanges();
                return new Response<Levels>(newLevel, "Nivel creado correctamente");

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        //Actualizar niveles
        public async Task<Response<Levels>> UpdateLevel(int id, Levels request)
        {
            try
            {
                Levels result = await _context.Levels.FirstOrDefaultAsync(x => x.idLevel == id);
                if (result == null)
                {
                    return new Response<Levels>(null, "No se encontro el nivel");
                }
                result.Nombre = request.Nombre;
                result.descripcion = request.descripcion;
               
                _context.Levels.Update(result);
                _context.SaveChanges();
                return new Response<Levels>(result, "Se actualizo correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        //Eliminar niveles
        public async Task<Response<Levels>> DeleteLevel(int id)
        {
            try
            {
                Levels result = await _context.Levels.FirstOrDefaultAsync(x => x.idLevel == id);
                if (result == null)
                {
                    return new Response<Levels>(null, "No se encontro el nivel");
                }
                _context.Levels.Remove(result);
                _context.SaveChanges();
                return new Response<Levels>(result, "Se elimino correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

    }
}
