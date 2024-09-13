using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace GUARDIAO_WS
{
  /// <summary>
  /// Summary description for descomplicaecv
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class guardiaows : System.Web.Services.WebService
  {
    public GUARDIAO_STRUCTS.SoapHeaderHelper mySoapHeader;
    private GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader validateSoap;
    private GUARDIAO_CONTROLLER.DATABASE.Empresa objEmpresa = null;
    private GUARDIAO_CONTROLLER.DATABASE.Especialidade objEspecialidade = null;
    private GUARDIAO_CONTROLLER.DATABASE.Escritorio objEscritorio = null;
    private GUARDIAO_CONTROLLER.DATABASE.Faculdade objFaculdade = null;
    private GUARDIAO_CONTROLLER.DATABASE.PercentualPreco objPercentualPreco = null;
    private GUARDIAO_CONTROLLER.DATABASE.Municipio objMunicipio = null;
    private GUARDIAO_CONTROLLER.DATABASE.TabelaPreco objTabelaPreco = null;
    private GUARDIAO_CONTROLLER.DATABASE.TipoConsulta objTipoConsulta = null;

    private GUARDIAO_CONTROLLER.DATABASE.TipoUsuario objTipoUsuario = null;
    private GUARDIAO_CONTROLLER.DATABASE.Usuario objUsuario = null;
    private GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios objUsuarios = null;
    private GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario objGrupoUsuario = null;
    private GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade objGrupoUsuarioFaculdade = null;
    private GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio objGrupoUsuarioEscritorio = null;
    private GUARDIAO_CONTROLLER.RECEITA_FEDERAL.ReceitaFederal objReceitaFederal = null;
    private GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento objSolicitacaoAtendimento = null;

    private GUARDIAO_CONTROLLER.DATABASE.HistoricoAtendimento objHistoricoAtendimento = null;
    private GUARDIAO_CONTROLLER.DATABASE.ParametrosSistema objParametrosSistema = null;

    private GUARDIAO_CONTROLLER.ASAAS.QrCodeEstaticoController objQrCodeEstatico = null;
    private GUARDIAO_CONTROLLER.ASAAS.PagamentoCartaoController pagamentoCartaoController = null;

    private GUARDIAO_CONTROLLER.SaldoController objSaldo = null;
    private GUARDIAO_CONTROLLER.DATABASE.Saldo objSaldo2 = null;
    private GUARDIAO_CONTROLLER.ExtratoController objExtratoController = null;
    private GUARDIAO_CONTROLLER.ASAAS.CustomerController objCustomerController = null;
    private GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento objSolicitacaoRecebimento = null;
    private GUARDIAO_CONTROLLER.DATABASE.Atendimento objAtendimento = null;
    private GUARDIAO_CONTROLLER.DATABASE.Atendimentos objAtendimentos = null;


    [WebMethod]
    public string GuardiaoCreateDirectories()
    {
      GUARDIAO_COMMOM.Directory.CreateSystemFolders();
      return "";
    }

    [WebMethod]
    public string GuardiaoEncrypt(string value)
    {
      return GUARDIAO_COMMOM.Crypto.EncryptSentence(value);
    }

    [WebMethod]
    public string GuardiaoDecrypt(string value)
    {
      return GUARDIAO_COMMOM.Crypto.DecryptSentence(value);
    }

    #region EMPRESA


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewEmpresa(string json)
    {
      string empresa = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEmpresa = new GUARDIAO_CONTROLLER.DATABASE.Empresa();
        empresa = objEmpresa.InsertNewEmpresa(json);
      }
      catch (Exception)
      {
        empresa = null;
      }

      return empresa;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateEmpresa(string json)
    {
      string empresa = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEmpresa = new GUARDIAO_CONTROLLER.DATABASE.Empresa();
        empresa = objEmpresa.UpdateEmpresa(json);
      }
      catch (Exception)
      {

        empresa = null;
      }

      return empresa;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetEmpresaByID(long empresa_id)
    {
      string empresa = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEmpresa = new GUARDIAO_CONTROLLER.DATABASE.Empresa();
        empresa = objEmpresa.GetEmpresaByID(empresa_id);
      }
      catch (Exception)
      {

        empresa = null;
      }

      return empresa;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEmpresa()
    {
      string empresas = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEmpresa = new GUARDIAO_CONTROLLER.DATABASE.Empresa();
        empresas = objEmpresa.GetAllEmpresa();
      }
      catch (Exception)
      {
        empresas = null;

      }

      return empresas;
    }


    #endregion

    #region Municipio

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewMunicipio(string json)
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.InsertNewMunicipio(json);
      }
      catch (Exception)
      {
        municipio = null;
      }

      return municipio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateMunicipio(string json)
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.UpdateMunicipio(json);
      }
      catch (Exception)
      {

        municipio = null;
      }

      return municipio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetMunicipioByID(long municipio_id)
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.GetMunicipioByID(municipio_id);
      }
      catch (Exception)
      {

        municipio = null;
      }

      return municipio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllMunicipioByUF(string UF)
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.GetAllMunicipioByUF(UF);
      }
      catch (Exception)
      {
        municipio = null;

      }

      return municipio;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllMunicipioByUFDart(string UF)
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.GetAllMunicipioByUFDart(UF);
      }
      catch (Exception)
      {
        municipio = null;

      }

      return municipio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUF()
    {
      string municipio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objMunicipio = new GUARDIAO_CONTROLLER.DATABASE.Municipio();
        municipio = objMunicipio.GetAllUF();
      }
      catch (Exception)
      {
        municipio = null;

      }

      return municipio;
    }
    #endregion

    #region ESCRITORIO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewEscritorio(string json)
    {
      string escritorio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEscritorio = new GUARDIAO_CONTROLLER.DATABASE.Escritorio();
        escritorio = objEscritorio.InsertNewEscritorio(json);
      }
      catch (Exception)
      {
        escritorio = null;
      }

      return escritorio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateEscritorio(string json)
    {
      string escritorio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEscritorio = new GUARDIAO_CONTROLLER.DATABASE.Escritorio();
        escritorio = objEscritorio.UpdateEscritorio(json);
      }
      catch (Exception)
      {
        escritorio = null;
      }

      return escritorio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetEscritorioByID(long escritorio_id)
    {
      string escritorio = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEscritorio = new GUARDIAO_CONTROLLER.DATABASE.Escritorio();
        escritorio = objEscritorio.GetEscritorioByID(escritorio_id);
      }
      catch (Exception)
      {
        escritorio = null;
      }

      return escritorio;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEscritorios()
    {
      string escritorios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEscritorio = new GUARDIAO_CONTROLLER.DATABASE.Escritorio();
        escritorios = objEscritorio.GetAllEscritorios();
      }
      catch (Exception)
      {
        escritorios = null;
      }

      return escritorios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEscritoriosAtivos()
    {
      string escritorios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEscritorio = new GUARDIAO_CONTROLLER.DATABASE.Escritorio();
        escritorios = objEscritorio.GetAllEscritoriosAtivos();
      }
      catch (Exception)
      {
        escritorios = null;
      }

      return escritorios;
    }

    #endregion

    #region ESPECIALIDADES

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewEspecialidade(string json)
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.InsertNewEspecialidade(json);
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateEspecialidade(string json)
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.UpdateEspecialidade(json);
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetEspecialidadeByID(long especialidade_id)
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadeByID(especialidade_id);
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetEspecialidadesData()
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadesData();
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }    
    
    
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetEspecialidadesDataByAdvogado(int idUsuario)
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetEspecialidadesDataByAdvogado(idUsuario);
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    } 
    
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetCrescimentoUsuario()
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        especialidade = objUsuario.GetQuantidadeUsuarioData();
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    } 
    
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetCrescimentoUsuarioByAdvogado(int idUsuario)
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        especialidade = objUsuario.GetQuantidadeUsuarioData(idUsuario);
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAtendimentosData()
    {
      string atendimentos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimentos = objAtendimentos.GetAtendimentosData();
      }
      catch (Exception)
      {
        atendimentos = null;
      }

      return atendimentos;
    }
    
    
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAtendimentosDataByAdvogado(int idUsuario)
    {
      string atendimentos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimentos = objAtendimentos.GetAtendimentosData(idUsuario);
      }
      catch (Exception)
      {
        atendimentos = null;
      }

      return atendimentos;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEspecialidade()
    {
      string especialidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidades = objEspecialidade.GetAllEspecialidade();
      }
      catch (Exception)
      {
        especialidades = null;
      }

      return especialidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEspecialidadeMobile()
    {
      string especialidade = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidade = objEspecialidade.GetAllEspecialidadeMobile();
      }
      catch (Exception)
      {
        especialidade = null;
      }

      return especialidade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllEspecialidadeByUsuarioID(long usuario_id)
    {
      string especialidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objEspecialidade = new GUARDIAO_CONTROLLER.DATABASE.Especialidade();
        especialidades = objEspecialidade.GetAllEspecialidadeByUsuarioID(usuario_id);
      }
      catch (Exception)
      {
        especialidades = null;
      }

      return especialidades;
    }

    #endregion

    #region FACULDADES

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewFaculdade(string json)
    {
      string faculdade = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objFaculdade = new GUARDIAO_CONTROLLER.DATABASE.Faculdade();
        faculdade = objFaculdade.InsertNewFaculdade(json);

      }
      catch (Exception)
      {
        faculdade = null;
      }

      return faculdade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateFaculdade(string json)
    {
      string faculdade = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objFaculdade = new GUARDIAO_CONTROLLER.DATABASE.Faculdade();
        faculdade = objFaculdade.UpdateFaculdade(json);

      }
      catch (Exception)
      {
        faculdade = null;
      }

      return faculdade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetFaculdadeByID(long faculdade_id)
    {
      string faculdade = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objFaculdade = new GUARDIAO_CONTROLLER.DATABASE.Faculdade();
        faculdade = objFaculdade.GetFaculdadeByID(faculdade_id);

      }
      catch (Exception)
      {
        faculdade = null;
      }

      return faculdade;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllFaculdades()
    {
      string faculdades = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objFaculdade = new GUARDIAO_CONTROLLER.DATABASE.Faculdade();
        faculdades = objFaculdade.GetAllFaculdades();

      }
      catch (Exception)
      {
        faculdades = null;
      }

      return faculdades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllFaculdadesAtivas()
    {
      string faculdades = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objFaculdade = new GUARDIAO_CONTROLLER.DATABASE.Faculdade();
        faculdades = objFaculdade.GetAllFaculdadesAtivas();

      }
      catch (Exception)
      {
        faculdades = null;
      }

      return faculdades;
    }

    #endregion

    #region PERCENTUAL PRECO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewPercentualPreco(string json)
    {
      string percentualPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objPercentualPreco = new GUARDIAO_CONTROLLER.DATABASE.PercentualPreco();
        percentualPreco = objPercentualPreco.InsertNewPercentualPreco(json);
      }
      catch (Exception)
      {
        percentualPreco = null;
      }

      return percentualPreco;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdatePercentualPreco(string json)
    {
      string percentualPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objPercentualPreco = new GUARDIAO_CONTROLLER.DATABASE.PercentualPreco();
        percentualPreco = objPercentualPreco.UpdatePercentualPreco(json);
      }
      catch (Exception)
      {
        percentualPreco = null;
      }

      return percentualPreco;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetPercentualPrecoByID(long percentualPreco_id)
    {
      string percentualPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objPercentualPreco = new GUARDIAO_CONTROLLER.DATABASE.PercentualPreco();
        percentualPreco = objPercentualPreco.GetPercentualPrecoByID(percentualPreco_id);
      }
      catch (Exception)
      {
        percentualPreco = null;
      }

      return percentualPreco;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllPercentualPrecoByAdvogadoByAtivo(long advogado_id, bool percentualPreco_ativo)
    {
      string percentualPrecos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objPercentualPreco = new GUARDIAO_CONTROLLER.DATABASE.PercentualPreco();
        percentualPrecos = objPercentualPreco.GetAllPercentualPrecoByAdvogadoByAtivo(advogado_id, percentualPreco_ativo);
      }
      catch (Exception)
      {
        percentualPrecos = null;
      }

      return percentualPrecos;
    }

    #endregion

    #region Tabela Preco

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewTabelaPreco(string json)
    {
      string tabelaPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTabelaPreco = new GUARDIAO_CONTROLLER.DATABASE.TabelaPreco();
        tabelaPreco = objTabelaPreco.InsertNewTabelaPreco(json);
      }
      catch (Exception)
      {
        tabelaPreco = null;
      }

      return tabelaPreco;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateTabelaPreco(string json)
    {
      string tabelaPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTabelaPreco = new GUARDIAO_CONTROLLER.DATABASE.TabelaPreco();
        tabelaPreco = objTabelaPreco.UpdateTabelaPreco(json);
      }
      catch (Exception)
      {

        tabelaPreco = null;
      }

      return tabelaPreco;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetTabelPrecoByID(long tabelaPreco_id)
    {
      string tabelaPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTabelaPreco = new GUARDIAO_CONTROLLER.DATABASE.TabelaPreco();
        tabelaPreco = objTabelaPreco.GetTabelaPrecoByID(tabelaPreco_id);
      }
      catch (Exception)
      {

        tabelaPreco = null;
      }

      return tabelaPreco;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllTabelaPreco()
    {
      string tabelaPreco = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTabelaPreco = new GUARDIAO_CONTROLLER.DATABASE.TabelaPreco();
        tabelaPreco = objTabelaPreco.GetAllTabelaPreco();
      }
      catch (Exception)
      {
        tabelaPreco = null;

      }

      return tabelaPreco;
    }
    #endregion

    #region Tipo Consulta

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewTipoConsulta(string json)
    {
      string tipoConsulta = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoConsulta = new GUARDIAO_CONTROLLER.DATABASE.TipoConsulta();
        tipoConsulta = objTipoConsulta.InsertNewTipoConsulta(json);
      }
      catch (Exception)
      {
        tipoConsulta = null;
      }

      return tipoConsulta;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateTipoConsulta(string json)
    {
      string tipoConsulta = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoConsulta = new GUARDIAO_CONTROLLER.DATABASE.TipoConsulta();
        tipoConsulta = objTipoConsulta.UpdateTipoConsulta(json);
      }
      catch (Exception)
      {

        tipoConsulta = null;
      }

      return tipoConsulta;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetTipoConsultaByID(long tipoConsulta_id)
    {
      string tipoConsulta = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoConsulta = new GUARDIAO_CONTROLLER.DATABASE.TipoConsulta();
        tipoConsulta = objTipoConsulta.GetTipoConsultaByID(tipoConsulta_id);
      }
      catch (Exception)
      {

        tipoConsulta = null;
      }

      return tipoConsulta;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllTipoConsulta()
    {
      string tipoConsulta = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoConsulta = new GUARDIAO_CONTROLLER.DATABASE.TipoConsulta();
        tipoConsulta = objTipoConsulta.GetAllTipoConsulta();
      }
      catch (Exception)
      {
        tipoConsulta = null;

      }

      return tipoConsulta;
    }
    #endregion

    #region TIPO USUARIO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewTipoUsuario(string json)
    {
      string tipoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoUsuario = new GUARDIAO_CONTROLLER.DATABASE.TipoUsuario();
        tipoUsuario = objTipoUsuario.InsertNewTipoUsuario(json);
      }
      catch (Exception)
      {
        tipoUsuario = null;
      }

      return tipoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateTipoUsuario(string json)
    {
      string tipoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoUsuario = new GUARDIAO_CONTROLLER.DATABASE.TipoUsuario();
        tipoUsuario = objTipoUsuario.UpdateTipoUsuario(json);
      }
      catch (Exception)
      {

        tipoUsuario = null;
      }

      return tipoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetTipUsuarioByID(long tipoUsuario_id)
    {
      string tipoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoUsuario = new GUARDIAO_CONTROLLER.DATABASE.TipoUsuario();
        tipoUsuario = objTipoUsuario.GetTipUsuarioByID(tipoUsuario_id);
      }
      catch (Exception)
      {

        tipoUsuario = null;
      }

      return tipoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllTipoUsuario(long especieUsuario_id)
    {
      string tipoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objTipoUsuario = new GUARDIAO_CONTROLLER.DATABASE.TipoUsuario();
        tipoUsuario = objTipoUsuario.GetAllTipoUsuario(especieUsuario_id);
      }
      catch (Exception)
      {
        tipoUsuario = null;

      }

      return tipoUsuario;
    }
    #endregion

    #region USUARIO



    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertUsuario(string json)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.InsertUsuario(json);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuariosByEspecie(long empresa_id, long especieUsuario_id)
    {
      string usuarios = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuariosByEspecie(empresa_id, especieUsuario_id);
      }
      catch (Exception)
      {
        usuarios = null;

      }

      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuariosByEspecieOnline(long empresa_id, long especieUsuario_id)
    {
      string usuarios = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuariosByEspecieOnline(empresa_id, especieUsuario_id);
      }
      catch (Exception)
      {
        usuarios = null;

      }

      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuariosByEspecieMobile(long empresa_id, long especieUsuario_id)
    {
      string usuarios = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuariosByEspecieMobile(empresa_id, especieUsuario_id);
      }
      catch (Exception)
      {
        usuarios = null;

      }

      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuariosByEspecieOnlineMobile(string latitude, string longitude)
    {
      string usuarios = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuariosByEspecieOnlineMobile(latitude, longitude);
      }
      catch (Exception)
      {
        usuarios = null;

      }

      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateUsuario(string json)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.UpdateUsuario(json);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetUsuarioById(long usuario_id)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.GetUsuarioById(usuario_id);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoValidarLoginUsuario(long usuario_cpf, string usuario_senha)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.ValidarLoginUsuario(usuario_cpf, usuario_senha);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertUsuarioOnline(string json)
    {
      string online = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        online = objUsuario.InsertUsuarioOnline(json);

      }
      catch (Exception)
      {
        online = null;
      }

      return online;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertUsuarioOffline(string json)
    {
      string online = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        online = objUsuario.InsertUsuarioOffline(json);

      }
      catch (Exception)
      {
        online = null;
      }

      return online;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuarioByAdvogadoID(long advogado_id)
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuarioByAdvogadoID(advogado_id);
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuarioByAdvogadoIDEspecianlidade(long advogado_id, long especialidade_id)
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuarioByAdvogadoIDEspecianlidade(advogado_id, especialidade_id);
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuarioAdvogadoAtivo()
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuarioAdvogadoAtivo();
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    } 
    
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuarioAdvogadoAtendimentoAtivo(int idUsuario)
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuarioAdvogadoAtivo(idUsuario);
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoAtivarUsuario(int idUsuario)
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.AtivaUsuario(idUsuario);
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoVerificaEmail(string usuario_email)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.VerificaEmailCadastrado(usuario_email);
      }
      catch (Exception)
      {
        usuario = null;
      }
      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoEsqueciMinhaSenha(string usuario_email)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.EsqueciMinhaSenha(usuario_email);

      }
      catch (Exception)
      {
        usuario = null;

      }
      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetUsuarioBySolicitacaoID(long solicitacaoAtendimento_id)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.GetUsuarioBySolicitacaoID(solicitacaoAtendimento_id);

      }
      catch (Exception)
      {

        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllUsuarioOnlineByFiltro(string json)
    {

      string usuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuarios = objUsuario.GetAllUsuarioOnlineByFiltro(json);
      }
      catch (Exception)
      {
        usuarios = null;
      }
      return usuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoVerificaUsuarioOnline(long usuario_id)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuario = new GUARDIAO_CONTROLLER.DATABASE.Usuario();
        usuario = objUsuario.VerificaUsuarioOnline(usuario_id);
      }
      catch (Exception)
      {

        usuario = null;
      }
      return usuario;
    }

    #endregion

    #region GRUPO USUARIO

    #region USUARIO GUARDIAO
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewGrupoUsuario(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoUsuario = objGrupoUsuario.InsertNewGrupoUsuario(json);
      }
      catch (Exception)
      {
        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateGrupoUsuario(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoUsuario = objGrupoUsuario.UpdateGrupoUsuario(json);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoUsuarioByID(long grupoUsuario_id)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoUsuario = objGrupoUsuario.GetGrupoUsuarioByID(grupoUsuario_id);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllGrupoUsuario()
    {
      string grupoUsuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoUsuarios = objGrupoUsuario.GetAllGrupoUsuario();
      }
      catch (Exception)
      {
        grupoUsuarios = null;

      }

      return grupoUsuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoFuncionalidadeDisponivel(long grupoUsuario_id)
    {
      string grupoFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoFuncionalidades = objGrupoUsuario.GetGrupoFuncionalidadeDisponivel(grupoUsuario_id);
      }
      catch (Exception)
      {
        grupoFuncionalidades = null;
      }
      return grupoFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(long grupoUsuario_id, long grupoFuncionalidade_id)
    {
      string itemFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        itemFuncionalidades = objGrupoUsuario.GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(grupoUsuario_id, grupoFuncionalidade_id);
      }
      catch (Exception)
      {
        itemFuncionalidades = null;
      }
      return itemFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoSaveFuncionalidadesGrupoUsuario(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuario = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuario();
        grupoUsuario = objGrupoUsuario.SaveFuncionalidadesGrupoUsuario(json);

      }
      catch (Exception)
      {
        grupoUsuario = null;
      }
      return grupoUsuario;
    }
    #endregion

    #region FACULDADE

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewGrupoUsuarioFaculdade(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoUsuario = objGrupoUsuarioFaculdade.InsertNewGrupoUsuario(json);
      }
      catch (Exception)
      {
        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateGrupoUsuarioFaculdade(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoUsuario = objGrupoUsuarioFaculdade.UpdateGrupoUsuario(json);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoUsuarioByIDFaculdade(long grupoUsuario_id)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoUsuario = objGrupoUsuarioFaculdade.GetGrupoUsuarioByID(grupoUsuario_id);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllGrupoUsuarioFaculdade()
    {
      string grupoUsuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoUsuarios = objGrupoUsuarioFaculdade.GetAllGrupoUsuario();
      }
      catch (Exception)
      {
        grupoUsuarios = null;

      }

      return grupoUsuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoFuncionalidadeDisponivelFaculdade(long grupoUsuario_id)
    {
      string grupoFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoFuncionalidades = objGrupoUsuarioFaculdade.GetGrupoFuncionalidadeDisponivel(grupoUsuario_id);
      }
      catch (Exception)
      {
        grupoFuncionalidades = null;
      }
      return grupoFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadadeFaculdade(long grupoUsuario_id, long grupoFuncionalidade_id)
    {
      string itemFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        itemFuncionalidades = objGrupoUsuarioFaculdade.GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(grupoUsuario_id, grupoFuncionalidade_id);
      }
      catch (Exception)
      {
        itemFuncionalidades = null;
      }
      return itemFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoSaveFuncionalidadesGrupoUsuarioFaculdade(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioFaculdade = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioFaculdade();
        grupoUsuario = objGrupoUsuarioFaculdade.SaveFuncionalidadesGrupoUsuario(json);

      }
      catch (Exception)
      {
        grupoUsuario = null;
      }
      return grupoUsuario;
    }

    #endregion

    #region ESCRITORIO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertNewGrupoUsuarioEscritorio(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoUsuario = objGrupoUsuarioEscritorio.InsertNewGrupoUsuario(json);
      }
      catch (Exception)
      {
        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateGrupoUsuarioEscritorio(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoUsuario = objGrupoUsuarioEscritorio.UpdateGrupoUsuario(json);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoUsuarioByIDEscritorio(long grupoUsuario_id)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoUsuario = objGrupoUsuarioEscritorio.GetGrupoUsuarioByID(grupoUsuario_id);
      }
      catch (Exception)
      {

        grupoUsuario = null;
      }

      return grupoUsuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllGrupoUsuarioEscritorio()
    {
      string grupoUsuarios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoUsuarios = objGrupoUsuarioEscritorio.GetAllGrupoUsuario();
      }
      catch (Exception)
      {
        grupoUsuarios = null;

      }

      return grupoUsuarios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetGrupoFuncionalidadeDisponivelEscritorio(long grupoUsuario_id)
    {
      string grupoFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoFuncionalidades = objGrupoUsuarioEscritorio.GetGrupoFuncionalidadeDisponivel(grupoUsuario_id);
      }
      catch (Exception)
      {
        grupoFuncionalidades = null;
      }
      return grupoFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadadeEscritorio(long grupoUsuario_id, long grupoFuncionalidade_id)
    {
      string itemFuncionalidades = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        itemFuncionalidades = objGrupoUsuarioEscritorio.GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(grupoUsuario_id, grupoFuncionalidade_id);
      }
      catch (Exception)
      {
        itemFuncionalidades = null;
      }
      return itemFuncionalidades;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoSaveFuncionalidadesGrupoUsuarioEscritorio(string json)
    {
      string grupoUsuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objGrupoUsuarioEscritorio = new GUARDIAO_CONTROLLER.DATABASE.GrupoUsuarioEscritorio();
        grupoUsuario = objGrupoUsuarioEscritorio.SaveFuncionalidadesGrupoUsuario(json);

      }
      catch (Exception)
      {
        grupoUsuario = null;
      }
      return grupoUsuario;
    }

    #endregion

    #endregion

    #region RECEITA FEDERAL

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetDadosCNPJ(string cnpj)
    {
      string empresa = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objReceitaFederal = new GUARDIAO_CONTROLLER.RECEITA_FEDERAL.ReceitaFederal();
        empresa = objReceitaFederal.GetDadosCNPJ(cnpj);
      }
      catch (Exception)
      {
        empresa = null;
      }
      return empresa;
    }

    #endregion

    #region SOLICITACAO ATENDIMENTO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertSolicitacao(string json)
    {
      string solicitacao = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        solicitacao = objSolicitacaoAtendimento.InsertSolicitacao(json);
      }
      catch (Exception)
      {
        solicitacao = null;
      }
      return solicitacao;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateStatusSolicitacao(long solicitacaoAtendimento_id, string newStatus)
    {
      string resul = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        resul = objSolicitacaoAtendimento.UpdateStatusSolicitacao(solicitacaoAtendimento_id, newStatus);
      }
      catch (Exception)
      {
        resul = null;
      }
      return resul;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateStatusSolicitacaoChat(long solicitacaoAtendimento_id, string solicitacaoAtendimento_identity)
    {
      string resul = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        resul = objSolicitacaoAtendimento.UpdateStatusSolicitacaoChat(solicitacaoAtendimento_id, solicitacaoAtendimento_identity);
      }
      catch (Exception)
      {
        resul = null;
      }
      return resul;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacoesAtendimento(long advogado_id, int solicitacaoAtendimento_tipo)
    {

      string solicitacaos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        solicitacaos = objSolicitacaoAtendimento.GetAllSolicitacoesAtendimento(advogado_id, solicitacaoAtendimento_tipo);
      }
      catch (Exception)
      {
        solicitacaos = null;

      }
      return solicitacaos;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacoesAtendimentoDart(long advogado_id, int solicitacaoAtendimento_tipo)
    {

      string solicitacaos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        solicitacaos = objSolicitacaoAtendimento.GetAllSolicitacoesAtendimentoDart(advogado_id, solicitacaoAtendimento_tipo);
      }
      catch (Exception)
      {
        solicitacaos = null;

      }
      return solicitacaos;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoDescartarSolicitacao(string json)
    {
      string descarte = null;
      try
      {



        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        descarte = objSolicitacaoAtendimento.DescartarSolicitacao(json);
      }
      catch (Exception)
      {
        descarte = null;
      }

      return descarte;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetSolicitacoesAtendimentoByID(long solicitacaoAtendimento_id)
    {

      string solicitacao = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoAtendimento();
        solicitacao = objSolicitacaoAtendimento.GetSolicitacoesAtendimentoByID(solicitacaoAtendimento_id);

      }
      catch (Exception)
      {
        solicitacao = null;
      }
      return solicitacao;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertAtendimento(string json)
    {
      string atendimento = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimento = objAtendimentos.InsertAtendimento(json);
      }
      catch (Exception)
      {
        atendimento = null;
      }

      return atendimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateAtendimento(string json)
    {
      string atendimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimento = objAtendimentos.UpdateAtendimento(json);
      }
      catch (Exception)
      {
        atendimento = null;
      }

      return atendimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAtendimentoByID(long atendimento_id)
    {
      string atendimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimento = objAtendimentos.GetAtendimentoByID(atendimento_id);
      }
      catch (Exception)
      {
        atendimento = null;
      }

      return atendimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAtendimentoBySolicitacaoAtendimentoID(long solicitacaoAtendimento_id)
    {
      string atendimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        atendimento = objAtendimentos.GetAtendimentoBySolicitacaoAtendimentoID(solicitacaoAtendimento_id);
      }
      catch (Exception)
      {
        atendimento = null;
      }

      return atendimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetRelatorioAtendimentos(string json)
    {
      string relatorios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        relatorios = objAtendimentos.GetRelatorioAtendimentos(json);
      }
      catch (Exception)
      {
        relatorios = null;
      }
      return relatorios;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetRelatorioAtendimentosAdnistrativo(string json)
    {
      string relatorios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        relatorios = objAtendimentos.GetRelatorioAtendimentosAdnistrativo(json);
      }
      catch (Exception)
      {
        relatorios = null;

      }
      return relatorios;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetRelatorioAtendimentosAdnistrativoDart(string json)
    {
      string relatorios = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objAtendimentos = new GUARDIAO_CONTROLLER.DATABASE.Atendimentos();
        relatorios = objAtendimentos.GetRelatorioAtendimentosAdnistrativoDart(json);
      }
      catch (Exception)
      {
        relatorios = null;

      }
      return relatorios;
    }

    #endregion

    #region HISTORICO ATENDIMENTO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertHistoricoAtendimento(string json)
    {
      string historico = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objHistoricoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.HistoricoAtendimento();
        historico = objHistoricoAtendimento.InsertHistoricoAtendimento(json);

      }
      catch (Exception)
      {
        historico = null;
      }
      return historico;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetHistoricoAtendimentoBySociliacaoAtendimentoID(long solicitacaoAtendimento_id)
    {
      string historico = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objHistoricoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.HistoricoAtendimento();
        historico = objHistoricoAtendimento.GetHistoricoAtendimentoBySociliacaoAtendimentoID(solicitacaoAtendimento_id);

      }
      catch (Exception)
      {
        historico = null;
      }
      return historico;
    }
    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetHistoricoAtendimentoByHistoricoID(long historicoAtendimento_id)
    {
      string historico = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objHistoricoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.HistoricoAtendimento();
        historico = objHistoricoAtendimento.GetHistoricoAtendimentoByHistoricoID(historicoAtendimento_id);

      }
      catch (Exception)
      {
        historico = null;
      }
      return historico;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetArquivosHistoricoAtendimentoByID(long historicoAtendimento_id)
    {
      string arquivos = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objHistoricoAtendimento = new GUARDIAO_CONTROLLER.DATABASE.HistoricoAtendimento();
        arquivos = objHistoricoAtendimento.GetArquivosHistoricoAtendimentoByID(historicoAtendimento_id);
      }
      catch (Exception)
      {
        arquivos = null;
      }
      return arquivos;
    }

    #endregion

    #region PARAMETROS SISTEMA

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertParametrosSistema(string json)
    {
      string parametros = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");


        objParametrosSistema = new GUARDIAO_CONTROLLER.DATABASE.ParametrosSistema();
        parametros = objParametrosSistema.InsertParametrosSistema(json);
      }
      catch (Exception)
      {
        parametros = null;
      }

      return parametros;

    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]

    public string GuardiaoGetParametrosSistema()
    {

      string parametros = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");


        objParametrosSistema = new GUARDIAO_CONTROLLER.DATABASE.ParametrosSistema();
        parametros = objParametrosSistema.GetParametrosSistema();
      }
      catch (Exception)
      {
        parametros = null;
      }

      return parametros;
    }

    #endregion

    #region SOLICITAÇÃO SAQUE

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertSolicitacaoRecebimento(string json)
    {
      string solicitacaoRecebimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.InsertSolicitacaoRecebimento(json);
      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;
      }

      return solicitacaoRecebimento;

    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacoesRecebimento()
    {

      string solicitacaoRecebimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimento();

      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;
      }

      return solicitacaoRecebimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacaoRecebimentoByUsuarioId(long usuario_id)
    {

      string solicitacaoRecebimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimentoByUsuarioId(usuario_id);

      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;
      }

      return solicitacaoRecebimento;
    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateSolicitacaoRecebimentoStatus(long solicitacaoRecebimento_id, string status)
    {

      string solicitacaoRecebimento = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.UpdateSolicitacaoRecebimentoStatus(solicitacaoRecebimento_id, status);

      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;
      }

      return solicitacaoRecebimento;
    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllAtendimentosByStatus(bool status)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");


        objAtendimento = new GUARDIAO_CONTROLLER.DATABASE.Atendimento();
        usuario = objAtendimento.GetAllAtendimentosByStatus(status);
      }
      catch (Exception)
      {
        usuario = null;
      }


      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacoesSaquesByFiltro(string json)
    {
      string solicitacoes = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacoes = objSolicitacaoRecebimento.GetAllSolicitacoesSaquesByFiltro(json);

      }
      catch (Exception)
      {
        solicitacoes = null;
      }
      return solicitacoes;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllSolicitacoesRecebimentoByID(long solicitacaoRecebimento_id)
    {

      string solicitacaoRecebimento = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimentoByID(solicitacaoRecebimento_id);

      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;

      }
      return solicitacaoRecebimento;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoUpdateSolicitacaoRecebimento(string json)
    {
      string solicitacaoRecebimento = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSolicitacaoRecebimento = new GUARDIAO_CONTROLLER.DATABASE.SolicitacaoRecebimento();
        solicitacaoRecebimento = objSolicitacaoRecebimento.UpdateSolicitacaoRecebimentoStatus(json);
      }
      catch (Exception)
      {
        solicitacaoRecebimento = null;
      }

      return solicitacaoRecebimento;
    }

    #endregion

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertAdvogadoCliente(string json)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuarios = new GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios();
        usuario = objUsuarios.InsertAdvogadoCliente(json);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertCustomerId(string json)
    {
      string customer_id = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuarios = new GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios();
        customer_id = objUsuarios.InsertCustomerId(json);
      }
      catch (Exception)
      {
        customer_id = null;
      }

      return customer_id;
    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoAleterarSenha(string json)
    {
      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuarios = new GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios();
        usuario = objUsuarios.AleterarSenha(json);
      }
      catch (Exception)
      {
        usuario = null;
      }

      return usuario;
    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertChavePix(string json)
    {
      string chavePix = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuarios = new GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios();
        chavePix = objUsuarios.InsertChavePix(json);
      }
      catch (Exception)
      {
        chavePix = null;
      }

      return chavePix;
    }


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoValidarLoginUsuarioApp(long usuario_cpf, string usuario_senha, int tipoUsuario = 0)//, bool isPersonLogin)
    {

      string usuario = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objUsuarios = new GUARDIAO_CONTROLLER.DATABASE.CrudUsuarios();
        usuario = objUsuarios.ValidarLoginUsuarioApp(usuario_cpf, usuario_senha);//, isPersonLogin);
      }
      catch (Exception ex)
      {
        usuario = null;
      }

      return usuario;
    }


    #region ASAAS

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetQrCode()
    {

      string qrCodeEstatico = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objQrCodeEstatico = new GUARDIAO_CONTROLLER.ASAAS.QrCodeEstaticoController();
        qrCodeEstatico = objQrCodeEstatico.GetQrCode();

      }
      catch (Exception)
      {
        qrCodeEstatico = null;
      }

      return qrCodeEstatico;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertQrCode(string json)
    {
      string qrCode = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objQrCodeEstatico = new GUARDIAO_CONTROLLER.ASAAS.QrCodeEstaticoController();
        qrCode = objQrCodeEstatico.InsertQrcode(json);
      }
      catch (Exception)
      {
        qrCode = null;
      }
      return qrCode;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertPagamentoCartao(string json)
    {
      string pagamentoCartao = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        pagamentoCartaoController = new GUARDIAO_CONTROLLER.ASAAS.PagamentoCartaoController();
        pagamentoCartao = pagamentoCartaoController.InsertPagamentoCartao(json);
      }
      catch (Exception)
      {
        pagamentoCartao = null;
      }
      return pagamentoCartao;
    }


    #endregion


    #region SALDO

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetSaldoByUsuarioId(long usuario_id)
    {
      string saldo = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objSaldo = new GUARDIAO_CONTROLLER.SaldoController();
        saldo = objSaldo.GetSaldo(usuario_id);
      }
      catch (Exception)
      {
        saldo = null;
      }
      return saldo;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoSaveSaldoUsuario(string json, int tipoExtrato_id)
    {
      string saldo = null;

      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");


        objSaldo2 = new GUARDIAO_CONTROLLER.DATABASE.Saldo();
        saldo = objSaldo2.SaveSaldoUsuario(json, tipoExtrato_id);
      }
      catch (Exception ex)
      {
        saldo = null;
      }
      return saldo;
    }

    #endregion



    #region EXTRATO


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetAllExtrato(long usuario_id)
    {
      string extrato = null;
      try
      {

        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objExtratoController = new GUARDIAO_CONTROLLER.ExtratoController();
        extrato = objExtratoController.GetAllExtratos(usuario_id);
      }
      catch (Exception)
      {
        extrato = null;

      }

      return extrato;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertExtrato(string json)
    {
      string extrtato = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objExtratoController = new GUARDIAO_CONTROLLER.ExtratoController();
        extrtato = objExtratoController.InsertExtrato(json);
      }
      catch (Exception)
      {
        extrtato = null;
      }
      return extrtato;
    }

    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoGetExtratoByFiltro(string json)
    {
      string extrato = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objExtratoController = new GUARDIAO_CONTROLLER.ExtratoController();
        extrato = objExtratoController.GetExtratoByFiltro(json);
      }
      catch (Exception)
      {

        extrato = null;


      }
      return extrato;
    }

    #endregion


    [WebMethod]
    [SoapHeader("mySoapHeader", Direction = SoapHeaderDirection.InOut)]
    public string GuardiaoInsertCustomer(string json)
    {
      string extrtato = null;
      try
      {
        if (mySoapHeader == null)
          throw new Exception("OPS! FAVOR INFORMAR AS CRENDENCIAIS.");
        if (validateSoap == null)
          validateSoap = new GUARDIAO_CONTROLLER.SOAPHEADER.ValidateSoapHeader();
        if (!validateSoap.Valdate(mySoapHeader))
          throw new Exception("OPS! CRENDENCIAIS INVÁLIDAS.");

        objCustomerController = new GUARDIAO_CONTROLLER.ASAAS.CustomerController();
        extrtato = objCustomerController.InsertCustomerController(json);
      }
      catch (Exception)
      {
        extrtato = null;
      }
      return extrtato;
    }

  }
}