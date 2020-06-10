using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Usuario.DAL;
using Usuario.Entidades;

namespace Usuario.BLL
{
    //ahora aqui hay que cear como guardara, modificara, eliminara, buscara, etc xd
    /*
     Empezamos con crear el metodo de Insertar
    pon esto dentro de la clase:
    publis static bool Insertar(Usuarios usuario){}
    dentro de las llaves cre una bool paso= false;
    en otra linea escribe Contexto contexto = new Contexto();
     debajo de la linea de contexto Escribe try y dale tab 
    escri
     */
    class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (!contexto.Usuarios.Any(A => A.UsuarioId == usuario.UsuarioId))
                {
                    if (usuario.UsuarioId == 0)
                    {
                        paso = Insertar(usuario);
                    }
                }
                else
                {
                    paso = Modificar(usuario);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Insertar(Usuarios usuario) 
        {


            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //Esto es para evitar que haga cosas que no debe xd
                // en el parentesis Escribe (contexto.Usuarios.Add(usuario)!=null)
                if (contexto.Usuarios.Add(usuario) != null)
                {
                    //aqui escribe  paso = contexto.SaveChanges()>0;
                    paso = contexto.SaveChanges() > 0;
                    
                }

            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;


        }
        //Aqui escrbiras public static bool Modificar(Usuarios usario) {}

        public static bool Modificar(Usuarios usuario) 
        {
            //Aqui escribiras Contexto contexto = new Contexto();
            Contexto contexto = new Contexto();
            //aqui escribe bool paso= false;
            bool paso = false;
            //  escribe try y dale tab 2 ves xd
            try
            {
                //Escribe contexto.Entry(usuario).State= EntityState.Modified;
                contexto.Entry(usuario).State = EntityState.Modified;
                //aqui escribe paso= contexto.SaveChanges()>0;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
               
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
           
            try
            {
                Usuarios usuario = contexto.Usuarios.Find(Id);
                contexto.Usuarios.Remove(usuario);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Usuarios Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario;

            try
            {
                usuario = contexto.Usuarios.Find(Id);
                
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool Existe(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                paso = contexto.Usuarios.Any(A => A.UsuarioId == id);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

    }
}
