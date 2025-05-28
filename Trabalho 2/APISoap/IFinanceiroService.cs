using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

[ServiceContract]
public interface IFinanceiroService
{
    [OperationContract]
    string PecaComMaiorPrejuizo();

    [OperationContract]
    decimal ObterCustosTotaisProducao(DateTime dataInicio, DateTime dataFim);

    [OperationContract]
    decimal ObterLucroTotal(DateTime dataInicio, DateTime dataFim);

    [OperationContract]
    List<PrejuizoPorPeca> ObterPrejuizoTotalPorPeca(DateTime dataInicio, DateTime dataFim);

    [OperationContract]
    DadosFinanceiros ObterDadosFinanceirosPorPeca(string codigoPeca);
}

[DataContract]
public class DadosFinanceiros
{
    [DataMember]
    public string Codigo_Peca { get; set; }

    [DataMember]
    public decimal Tempo_Producao { get; set; }

    [DataMember]
    public decimal Custo_Producao { get; set; }

    [DataMember]
    public decimal Prejuizo { get; set; }

    [DataMember]
    public decimal Lucro { get; set; }
}

[DataContract]
public class PrejuizoPorPeca
{
    [DataMember]
    public string Codigo { get; set; }

    [DataMember]
    public decimal Prejuizo { get; set; }
}
