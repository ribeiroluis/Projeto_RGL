﻿using Community.CsharpSqlite.SQLiteClient;
using System.Text;
using Projeto_RGL.BaixarArquivos;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System;
using Projeto_RGL.BaixarArquivos;

namespace Projeto_RGL
{
    public class BancodeDadosProdutos
    {

        public void CarregaLista(List<BaixarArquivoProdutos.ProdutoXML> Lista)
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            isf.DeleteFile("Produto.db");

            using (SqliteConnection conn = new SqliteConnection("Version=3,uri=file:Produto.db"))
            {
                conn.Open();

                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE Produto ( [id] INTEGER, [Nome] TEXT)";
                    cmd.ExecuteNonQuery();
                    cmd.Transaction = conn.BeginTransaction();
                    cmd.CommandText = "INSERT INTO Produto(id, Nome) VALUES(@id, @Nome);SELECT last_insert_rowid();";
                    cmd.Parameters.Add("@id", null);
                    cmd.Parameters.Add("@Nome", null);

                    /*                    
                    cmd.CommandText = "CREATE TABLE Produto ( [id] INTEGER PRIMARY KEY, [col] INTEGER UNIQUE, [col2] INTEGER, [col3] REAL, [col4] TEXT, [col5] BLOB)";
                    cmd.ExecuteNonQuery();
                    cmd.Transaction = conn.BeginTransaction();
                    cmd.CommandText = "INSERT INTO Produto(col, col2, col3, col4, col5) VALUES(@col, @col2, @col3, @col4, @col5);SELECT last_insert_rowid();";
                    cmd.Parameters.Add("@col", null);
                    cmd.Parameters.Add("@col2", null);
                    cmd.Parameters.Add("@col3", null);
                    cmd.Parameters.Add("@col4", null);
                    cmd.Parameters.Add("@col5", null);

                    DateTime start = DateTime.Now;

                    for (int i = 0; i < 100; i++)
                    {
                        cmd.Parameters["@col"].Value = i;
                        cmd.Parameters["@col2"].Value = i;
                        cmd.Parameters["@col3"].Value = i * 0.515;
                        cmd.Parameters["@col4"].Value = "สวัสดี な. あ · か · さ · た · な · は · ま · や · ら · わ. 形容詞 hello " + i;
                        cmd.Parameters["@col5"].Value = Encoding.UTF8.GetBytes("สวัสดี");

                        object s = cmd.ExecuteScalar();
                    }*/

                    foreach (var item in Lista)
                    {
                        cmd.Parameters["@id"].Value = item.idProduto;
                        cmd.Parameters["@Nome"].Value = item.nome;
                        object s = cmd.ExecuteScalar();
                    }

                    cmd.Transaction.Commit();
                    cmd.Transaction = null;


                    cmd.CommandText = "SELECT * FROM Produto WHERE ID = 94";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = reader.GetString(1);
                        }
                    }
                    conn.Close();
                }


                /*cmd.CommandText = "SELECT * FROM Produto";
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //var bytes = (byte[])reader.GetValue(2);
                        /*this.lstResult.Items.Add(string.Format("{0},{1},{2},{3},{4}, {5}",
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetDouble(3),
                            reader.GetString(4),
                            Encoding.UTF8.GetString(bytes, 0, bytes.Length)));
                    }
                }*/
                var conexao = conn.ConnectionString;
                conn.Close();
            }
        }

        public List<BaixarArquivoProdutos.ProdutoXML> PesquisaProduto()
        {
            BaixarArquivoProdutos.ProdutoXML p;
            List<BaixarArquivoProdutos.ProdutoXML> list = new List<BaixarArquivos.BaixarArquivoProdutos.ProdutoXML>();

            using (SqliteConnection conn = new SqliteConnection("Version=3,uri=file:Produto.db"))
            {
                conn.Open();
                
                IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
               var teste = isf.FileExists("Produto.db");
                
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.ExecuteNonQuery();
                    cmd.Transaction = conn.BeginTransaction();
                    cmd.Transaction.Commit();
                    cmd.Transaction = null;
                    cmd.CommandText = "SELECT * FROM Produto";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new BaixarArquivos.BaixarArquivoProdutos.ProdutoXML();
                            p.nome = reader.GetString(1);
                            list.Add(p);
                        }
                    }

                    conn.Close();
                }
            }
            return list;
        }
    }
}