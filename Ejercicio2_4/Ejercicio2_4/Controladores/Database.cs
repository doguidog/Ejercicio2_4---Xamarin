using Ejercicio2_4.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_4.Controladores
{
    public class Database
    {

        readonly SQLiteAsyncConnection dbase;

        public Database(string pathdb)
        {
            dbase = new SQLiteAsyncConnection(pathdb);
            dbase.CreateTableAsync<videorecord>().Wait();
        }

        public Task<List<videorecord>> listarvid()
        {
            return dbase.Table<videorecord>().ToListAsync();
        }
        public Task<videorecord> listar(int pid)
        {
            return dbase.Table<videorecord>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }
        public Task<int> Guardar(videorecord video)
        {
            if (video.id != 0)
            {
                return dbase.UpdateAsync(video);
            }
            else
            {
                return dbase.InsertAsync(video);
            }

        }

        public Task<int> eliminar(videorecord videos)
        {
            return dbase.DeleteAsync(videos);
        }

    }
}
