using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AddIdioma
    {
        DAOUsuario dao = new DAOUsuario();
        DataTable tablaidi = new DataTable();
        DataTable componentes = new DataTable();
        DataTable paraultimoComp = new DataTable();
        DataTable paraultimoIdi = new DataTable();
        DataTable sinTraducirComp = new DataTable();
        int sesionIdiomaAct, sesionIdiomaEsc, viewEsc;
        int soloComp = 0, ultimoComp = 0, ultimoIdi=0;
        int ultimoMen = 0;
        DataTable mensajes = new DataTable();
        DataTable paraultimoMen = new DataTable();
        DataTable sinTraducirMen = new DataTable();
        string idioma;
        List<string> compoSinTrad = new List<string>();
        List<string> compoAct = new List<string>();
        List<string> paraAct = new List<string>();
        DataTable formularioAct = new DataTable();
        DataTable formularioEsc = new DataTable();
        List<string> lisForm = new List<string>();
        string alerta = "";
        Hashtable mensa = new Hashtable();
        public AddIdioma(string StrIdioma)
        {
            DataTable idi = new DataTable();
            idi = dao.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == StrIdioma.ToLower())
                { 
                    sesionIdiomaAct = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
        }
        public void ValidarExistente(string idioma, string terminacion, string view)
        {
            this.idioma = idioma;
            mensajesTrad(sesionIdiomaAct, 25);
            if (validarCajas(idioma, terminacion))
            {
                tablaidi = dao.traerIdioma();
                for (int i = 0; i < tablaidi.Rows.Count; i++)
                {
                    if (tablaidi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower() || tablaidi.Rows[i]["terminacion"].ToString().ToLower() == terminacion.ToLower())
                    {
                        soloComp = 1;
                        alerta = mensa["1"].ToString();
                    }
                }
                if (soloComp == 1)
                {
                    DataTable idi = new DataTable();
                    idi = dao.traerIdioma();
                    
                    
                    for (int i = 0; i < idi.Rows.Count; i++)
                    {
                        if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                        {
                            sesionIdiomaEsc = int.Parse(idi.Rows[i]["id"].ToString());
                        }
                    }
                    formularioAct = dao.traerViews(sesionIdiomaAct);
                    for (int i = 0; i < formularioAct.Rows.Count; i++)
                    {
                        if (formularioAct.Rows[i]["texto"].ToString() == view)
                        {
                            viewEsc = int.Parse(formularioAct.Rows[i]["control"].ToString());
                        }
                    }
                    formularioEsc = dao.traerViews(sesionIdiomaEsc);
                    for (int i = 0; i < formularioEsc.Rows.Count; i++)
                    {
                        if (formularioEsc.Rows[i]["texto"].ToString() == view)
                        {
                            viewEsc = int.Parse(formularioEsc.Rows[i]["control"].ToString());
                        }
                    }
                    sinTraducirComp = dao.traerTodosComponentesUnIdioma(sesionIdiomaEsc);
                    componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                    sinTraducirMen = dao.traerTodosMensajesUnIdioma(sesionIdiomaEsc, viewEsc);
                    mensajes = dao.traerTodosMensajesUnIdioma(sesionIdiomaAct, viewEsc);
                    HacerListaSinTrad();
                    HacerListaSinTradNueva();
                }
                else
                {
                    componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                    mensajes = dao.traerTodosMensajesUnIdioma(sesionIdiomaAct, viewEsc);
                    
                    
                    paraultimoIdi = dao.traerUltimoIDIdi();
                    ultimoIdi = int.Parse(paraultimoIdi.Rows[0]["id"].ToString()) + 1;
                    dao.crearIdioma(ultimoIdi, idioma, terminacion);


                    for (int i = 0; i < componentes.Rows.Count; i++)
                    {
                        paraultimoComp = dao.traerUltimoIDComp();
                        ultimoComp = int.Parse(paraultimoComp.Rows[0]["id"].ToString());
                        dao.crearComponente(ultimoComp + 1, int.Parse(componentes.Rows[i]["formulario_id"].ToString()), ultimoIdi, componentes.Rows[i]["control"].ToString());
                    }
                    for(int i = 0; i < mensajes.Rows.Count; i++)
                    {
                        paraultimoMen = dao.traerUltimoIDMen();
                        ultimoMen = int.Parse(paraultimoMen.Rows[0]["id"].ToString()) + 1;
                        dao.crearMensaje(ultimoMen, mensajes.Rows[i]["nombre"].ToString(), int.Parse(mensajes.Rows[i]["msj"].ToString()), ultimoIdi, int.Parse(mensajes.Rows[i]["clase"].ToString()));
                    }
                    alerta = mensa["2"].ToString();
                }
            }
        }
        public DataTable getComponentes()
        {
            return componentes;
        }
        public void HacerListaSinTrad()
        {
            try
            {
                for (int i = 0; i < componentes.Rows.Count; i++)
                {
                    if (sinTraducirComp.Rows[i]["texto"].ToString() == "" && int.Parse(sinTraducirComp.Rows[i]["formulario_id"].ToString()) == viewEsc)
                    {
                        compoAct.Add(componentes.Rows[i]["texto"].ToString());
                    }

                }
                for (int i = 0; i < mensajes.Rows.Count; i++)
                {
                    if (sinTraducirMen.Rows[i]["texto"].ToString() == "")
                    {
                        compoAct.Add(mensajes.Rows[i]["texto"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
        public List<string> getListaSinTrad()
        {
            return compoSinTrad;
        }
        public List<string> getListaAct()
        {
            return compoAct;
        }

        public void ActualizarIdioma(string controlAct, string texto)
        {
            if (validarTrad(texto))
            {
                string controlNuevo;
                for (int i = 0; i < componentes.Rows.Count; i++)
                {
                    if (componentes.Rows[i]["texto"].ToString() == controlAct)
                    {
                        controlNuevo = componentes.Rows[i]["control"].ToString();
                        dao.ActualizarIdioma(sesionIdiomaEsc, controlNuevo, texto);
                    }
                }
                alerta = mensa["3"].ToString();
                componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                HacerListaSinTrad();
            }
        }

        public bool validarCajas(string idioma, string terminacion)
        {
            if(idioma=="" || terminacion == "")
            {
                alerta = mensa["4"].ToString();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validarTrad(string texto)
        {
            if (texto == "")
            {
                alerta = mensa["5"].ToString();
                return false;
            }
            else
            {
                return true;
            }
        }
        //y tmb se puede borrar un idioma, si borra todo pero hay que dejar al menos un idioma
        //asiiii dijo monje avl. pero yo estaba pensando que podiamos dejar 2 idiomas minimo, osea ingles y español
        public void ActIdiomaViejo(string controlAct, string texto)
        {
            if (validarTrad(texto))
            {
                string controlNuevo;
                for (int i = 0; i < componentes.Rows.Count; i++)
                {
                    if (componentes.Rows[i]["texto"].ToString() == controlAct)
                    {
                        controlNuevo = componentes.Rows[i]["control"].ToString();
                        dao.ActualizarIdioma(sesionIdiomaEsc, controlNuevo, texto);
                    }
                }
                componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                HacerListaSinTradNueva();
            }
        }
        public void HacerListaSinTradNueva()
        {
            try
            {
                for (int i = 0; i < componentes.Rows.Count; i++)
                {
                    if (sinTraducirComp.Rows[i]["texto"].ToString() != "" && int.Parse(sinTraducirComp.Rows[i]["formulario_id"].ToString()) == viewEsc)
                    {
                        paraAct.Add(componentes.Rows[i]["texto"].ToString());
                    }

                }
                for (int i = 0; i < mensajes.Rows.Count; i++)
                {
                    if (sinTraducirMen.Rows[i]["texto"].ToString() != "")
                    {
                        paraAct.Add(mensajes.Rows[i]["texto"].ToString());
                    }
                }
            }
            catch(Exception ex)
            {

            }

        }
        public List<string> getListaParaAct()
        {
            return paraAct;
        }

        public void BorrarALV()
        {
            if (sesionIdiomaEsc == 1 | sesionIdiomaEsc == 2)
            {
                alerta = mensa["6"].ToString();
            } 
            else
            {
                dao.EliminarMensajesIdioma(sesionIdiomaEsc);
                dao.EliminarCompoIdioma(sesionIdiomaEsc);
                dao.EliminarIdioma(sesionIdiomaEsc);
                alerta = mensa["7"].ToString();
            }
        }
        int kIdioma;
        public Hashtable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            Hashtable compIdioma = new Hashtable();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dAO.traerComponentes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["control"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return compIdioma;
        }
        public List<string> ParaListaVistaActual()
        {
            List<string> lista = new List<string>();
            DataTable a = dao.traerViews(sesionIdiomaAct);
            lista.Add("  ---  ");
            for(int i =0; i< a.Rows.Count; i++)
            {
                lista.Add(a.Rows[i]["texto"].ToString());
            }
            return lista;
        }
        public List<string> ParaListaVistaEscojida()
        {
            List<string> lista = new List<string>();
            DataTable a = dao.traerViews(sesionIdiomaEsc);
            lista.Add("  ---  ");
            for (int i = 0; i < a.Rows.Count; i++)
            {
                lista.Add(a.Rows[i]["texto"].ToString());
            }
            return lista;
        }
        public string GetAlerta()
        {
            return alerta;
        }

        public void mensajesTrad(int idioma, int constante)
        {
            DAOUsuario dao = new DAOUsuario();

            DataTable mss = new DataTable();
            mss = dao.traerMensajes(idioma, constante);
            for (int i = 0; i < mss.Rows.Count; i++)
            {
                mensa.Add(mss.Rows[i]["msj"].ToString(), mss.Rows[i]["texto"].ToString());
            }
        }
    }
    
}
