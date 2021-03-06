﻿Imports System.Data.SqlClient
Imports System.Data.SqlServerCe

Public Module BaseDatos

    Private cadenaConexionPrincipal As String
    Private cadenaConexionInformacion As String
    Private cadenaConexionCatalogo As String
    Private cadenaConexionAgenda As String
    Public conexionPrincipal As New SqlCeConnection()
    Public conexionInformacion As New SqlConnection()
    Public conexionCatalogo As New SqlConnection()
    Public conexionAgenda As New SqlConnection()

    Public Property ECadenaConexionPrincipal() As String
        Get
            Return BaseDatos.cadenaConexionPrincipal
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionPrincipal = value
        End Set
    End Property
    Public Property ECadenaConexionInformacion() As String
        Get
            Return BaseDatos.cadenaConexionInformacion
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionInformacion = value
        End Set
    End Property
    Public Property ECadenaConexionCatalogo() As String
        Get
            Return BaseDatos.cadenaConexionCatalogo
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionCatalogo = value
        End Set
    End Property
    Public Property ECadenaConexionAgenda() As String
        Get
            Return BaseDatos.cadenaConexionAgenda
        End Get
        Set(value As String)
            BaseDatos.cadenaConexionAgenda = value
        End Set
    End Property

    Public Sub AbrirConexionPrincipal()

        BaseDatos.ECadenaConexionPrincipal = String.Format("Data Source={0};Password={1}", BaseDatos.ECadenaConexionPrincipal, "@berry2017") ' Contraseña fija.
        conexionPrincipal.ConnectionString = BaseDatos.ECadenaConexionPrincipal

    End Sub

    Public Sub AbrirConexionInformacion()

        BaseDatos.ECadenaConexionInformacion = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaNotificacionesCorreo.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionInformacion, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.usuarioSql, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.contrasenaSql)
        conexionInformacion.ConnectionString = BaseDatos.ECadenaConexionInformacion

    End Sub

    Public Sub AbrirConexionCatalogo()

        BaseDatos.ECadenaConexionCatalogo = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaNotificacionesCorreo.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionCatalogo, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.usuarioSql, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.contrasenaSql)
        conexionCatalogo.ConnectionString = BaseDatos.ECadenaConexionCatalogo

    End Sub

    Public Sub AbrirConexionAgenda()

        BaseDatos.ECadenaConexionAgenda = String.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", LogicaNotificacionesCorreo.DatosEmpresaPrincipal.instanciaSql, BaseDatos.ECadenaConexionAgenda, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.usuarioSql, LogicaNotificacionesCorreo.DatosEmpresaPrincipal.contrasenaSql)
        conexionAgenda.ConnectionString = BaseDatos.ECadenaConexionAgenda

    End Sub

End Module
