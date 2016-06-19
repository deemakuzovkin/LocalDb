using System;
using System.Data.SqlClient;
using System.Windows;

namespace LocalDb.Data.SqlCommand
{
    /// <summary>
    /// Статический класс для генерации базы данных.
    /// </summary>
    public static class SqlExecuteCommands
    {
        /// <summary>
        /// Создание локальной базы данных.
        /// </summary>
        /// <param name="basePath">Путь к базе данных.</param>
        /// <param name="baseName">Название базы данных.</param>
        public static void CreateDataBase(string basePath, string baseName = "LDB")
        {
            try
            {
                var connection = new SqlConnection(@"server=(localdb)\v11.0");
                using (connection)
                {
                    connection.Open();
                    string sql = string.Format(@"
                    USE master
                    IF EXISTS (SELECT name FROM sys.databases WHERE name = '{0}') DROP DATABASE {0}
                    CREATE DATABASE [{0}]
                    ON PRIMARY (NAME={0}_data, FILENAME = '{1}\{0}_data.mdf')
                    LOG ON (NAME={0}_log, FILENAME = '{1}\{0}_log.ldf') 
                    COLLATE Cyrillic_General_CI_AS", baseName, basePath);
                    var command = new System.Data.SqlClient.SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}",ex.Message));
            }
        }

        /// <summary>
        /// Создание таблицы.
        /// </summary>
        /// <param name="tableName">Название таблицы.</param>
        public static void CreateTable(string tableName)
        {
            try
            {
                var connection = new SqlConnection(@"server=(localdb)\v11.0");
                using (connection)
                {
                    connection.Open();
                    var query = string.Format(@"
                    USE [LDB]
                    CREATE TABLE [dbo].[{0}](
                    [Код_товара] [int] IDENTITY(1,1) NOT NULL,
                    [Название] [varchar](255) NULL,
                    [Автор] [varchar](255) NULL,
                    [Издательство] [varchar](255) NULL,
                     CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
                    ([Код_товара] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY] ", tableName);

                    var command = new System.Data.SqlClient.SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message));
            }
        }
    }
}
