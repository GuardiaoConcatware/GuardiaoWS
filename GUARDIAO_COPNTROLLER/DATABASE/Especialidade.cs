using GUARDIAO_CRUD.DATABASE;
using GUARDIAO_STRUCTS.DATABASE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
  public class Especialidade
  {
    private GUARDIAO_CRUD.DATABASE.Especialidade objEspecialidade = null;
    public string InsertNewEspecialidade(string json)
    {
      GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade = null;
      try
      {
        especialidade = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Especialidade>(json);
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.InsertNewEspecialidade(especialidade);
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
        especialidade.resultCode = -1;
        especialidade.resultDescription = ex.Message;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string UpdateEspecialidade(string json)
    {
      GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade = null;
      try
      {
        especialidade = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Especialidade>(json);
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.UpdateEspecialidade(especialidade);
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
        especialidade.resultCode = -1;
        especialidade.resultDescription = ex.Message;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string GetEspecialidadeByID(long especialidade_id)
    {
      GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadeByID(especialidade_id);
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
        especialidade.resultCode = -1;
        especialidade.resultDescription = ex.Message;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string GetEspecialidadesData()
    {
      List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeQuantidade> especialidade = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadesData();
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(EspecialidadeQuantidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string GetEspecialidadesDataByAdvogado(int idUsuario)
    {
      List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeQuantidade> especialidade = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadesDataByAdvogado(idUsuario);
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(EspecialidadeQuantidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string GetAllEspecialidade()
    {
      List<GUARDIAO_STRUCTS.DATABASE.Especialidade> especialidades = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidades = objEspecialidade.GetAllEspecialidade();
      }
      catch (Exception ex)
      {
        especialidades = null;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidades);
    }
    public string GetAllEspecialidadeMobile()
    {
      GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile especialidade = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetAllEspecialidadeMobile();
      }
      catch (Exception ex)
      {
        if (especialidade == null)
          especialidade = new GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile();
        especialidade.resultCode = -1;
        especialidade.resultDescription = ex.Message;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidade);
    }

    public string GetAllEspecialidadeByUsuarioID(long usuario_id)
    {
      List<GUARDIAO_STRUCTS.DATABASE.Especialidade> especialidades = null;
      try
      {
        objEspecialidade = new GUARDIAO_CRUD.DATABASE.Especialidade();
        especialidades = objEspecialidade.GetAllEspecialidadeByUsuarioID(usuario_id);
      }
      catch (Exception ex)
      {
        especialidades = null;
        GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
      }

      return JsonConvert.SerializeObject(especialidades);
    }
  }
}
