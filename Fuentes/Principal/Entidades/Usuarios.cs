﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuarios
    {

        private int idEmpresa;
        private int id;
        private string nombre;
        private string contrasena;
        private int nivel;
        private bool accesoTotal;
        private int idArea;
        
        public int IdEmpresa
        {
            get { return idEmpresa; }
            set { idEmpresa = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
        public bool AccesoTotal
        {
            get { return accesoTotal; }
            set { accesoTotal = value; }
        }
        public int IdArea
        {
            get { return idArea; }
            set { idArea = value; }
        }

        public void Guardar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "INSERT INTO Usuarios VALUES (@idEmpresa, @id, @nombre, @contrasena, @nivel, @accesoTotal, @idArea)";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@contrasena", this.Contrasena);
                comando.Parameters.AddWithValue("@nivel", this.Nivel);
                comando.Parameters.AddWithValue("@accesoTotal", this.AccesoTotal);
                comando.Parameters.AddWithValue("@idArea", this.IdArea);
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public void Editar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "UPDATE Usuarios SET Nombre=@nombre, Contrasena=@contrasena, Nivel=@nivel, AccesoTotal=@accesoTotal, IdArea=@idArea WHERE IdEmpresa=@idEmpresa AND Id=@id";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@id", this.Id);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@contrasena", this.Contrasena);
                comando.Parameters.AddWithValue("@nivel", this.Nivel);
                comando.Parameters.AddWithValue("@accesoTotal", this.AccesoTotal);
                comando.Parameters.AddWithValue("@idArea", this.IdArea);
                BaseDatos.conexionInformacion.Close();
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public void Eliminar()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "DELETE FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Id=@id";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@id", this.Id);                
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public void EliminarTodo()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "DELETE FROM Usuarios WHERE IdEmpresa=@idEmpresa";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa); 
                BaseDatos.conexionInformacion.Open();
                comando.ExecuteNonQuery();
                BaseDatos.conexionInformacion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public string ObtenerPorId()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Id=@id";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    this.IdEmpresa = Convert.ToInt32(dataReader["idEmpresa"].ToString());
                    this.Id = Convert.ToInt32(dataReader["id"].ToString());
                    this.Nombre = dataReader["nombre"].ToString();
                    this.Contrasena = dataReader["contrasena"].ToString();
                    this.Nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    this.AccesoTotal = Convert.ToBoolean(dataReader["accesoTotal"].ToString());
                    this.IdArea = Convert.ToInt32(dataReader["idArea"].ToString());
                }
                if (!dataReader.HasRows)
                {
                    return string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty + "|" + string.Empty;
                }
                BaseDatos.conexionInformacion.Close();
                return this.IdEmpresa + "|" + this.Id + "|" + this.Nombre + "|" + this.Contrasena + "|" + this.Nivel + "|" + this.AccesoTotal + "|" + this.IdArea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public List<Usuarios> ObtenerPorNombre()
        {

            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Nombre=@nombre";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Usuarios usuarios = default(Usuarios);
                while (dataReader.Read())
                {
                    usuarios = new Usuarios();
                    usuarios.idEmpresa = Convert.ToInt32(dataReader["idEmpresa"].ToString());
                    usuarios.id = Convert.ToInt32(dataReader["id"].ToString());
                    usuarios.nombre = dataReader["nombre"].ToString();
                    usuarios.contrasena = dataReader["contrasena"].ToString();
                    usuarios.nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    usuarios.accesoTotal = Convert.ToBoolean(dataReader["accesoTotal"].ToString());
                    usuarios.idArea = Convert.ToInt32(dataReader["idArea"].ToString());
                    lista.Add(usuarios);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public bool ValidarPorId()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Id=@id";
                comando.Parameters.AddWithValue("@idEmpresa", this.IdEmpresa);
                comando.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }                
                BaseDatos.conexionInformacion.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public bool ValidarActividadPorId()
        {

            try
            {
                bool resultado = false;
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionAgenda;
                comando.CommandText = "SELECT * FROM Actividades WHERE IdUsuario=@id OR IdUsuarioDestino=@id"; 
                comando.Parameters.AddWithValue("@id", this.Id);
                BaseDatos.conexionAgenda.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                BaseDatos.conexionAgenda.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionAgenda.Close();
            }

        }

        public List<Usuarios> ObtenerListado()
        {

            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios";
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Usuarios usuarios;
                while (dataReader.Read())
                {
                    usuarios = new Usuarios();
                    usuarios.IdEmpresa = Convert.ToInt32(dataReader["idEmpresa"].ToString());
                    usuarios.Id = Convert.ToInt32(dataReader["id"].ToString());
                    usuarios.Nombre = dataReader["nombre"].ToString();
                    usuarios.Contrasena = dataReader["contrasena"].ToString();
                    usuarios.Nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    usuarios.AccesoTotal = Convert.ToBoolean(dataReader["accesoTotal"].ToString());
                    usuarios.IdArea =Convert.ToInt32(dataReader["idArea"].ToString());
                    lista.Add(usuarios);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

        public List<Usuarios> ObtenerListaPorId()
        {

            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = BaseDatos.conexionInformacion;
                comando.CommandText = "SELECT * FROM Usuarios WHERE IdEmpresa=@idEmpresa AND Id=@id";
                comando.Parameters.AddWithValue("@idEmpresa", this.idEmpresa);
                comando.Parameters.AddWithValue("@id", this.id);
                BaseDatos.conexionInformacion.Open();
                SqlDataReader dataReader = comando.ExecuteReader();
                Usuarios usuarios = default(Usuarios);
                while (dataReader.Read())
                {
                    usuarios = new Usuarios();
                    usuarios.idEmpresa = Convert.ToInt32(dataReader["idEmpresa"].ToString());
                    usuarios.id = Convert.ToInt32(dataReader["id"].ToString());
                    usuarios.nombre = dataReader["nombre"].ToString();
                    usuarios.contrasena = dataReader["contrasena"].ToString();
                    usuarios.nivel = Convert.ToInt32(dataReader["nivel"].ToString());
                    usuarios.accesoTotal = Convert.ToBoolean(dataReader["accesoTotal"].ToString());
                    usuarios.idArea = Convert.ToInt32(dataReader["idArea"].ToString());
                    lista.Add(usuarios);
                }
                BaseDatos.conexionInformacion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                BaseDatos.conexionInformacion.Close();
            }

        }

    }
}
