using Core.Interfaces;
using System;
using System.IO;

namespace DBSqlLite
{
    public class BancoSqlite : IBancoDados
    {
        public string Filepath;
        public static BancoSqlite Instance;

        public static string CaminhoDoBanco
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new BancoSqlite();
                    var currentLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    Instance.Filepath = Path.Combine(currentLocation, "BancoDeDados.db3");
                }
                return Instance.Filepath;

            }
        }

        public void Init()
        {
            Mapper.Mapper.CreateMapper();
        }
    }
}