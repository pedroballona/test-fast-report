# Utilizando o FastReport para gerar um relatório

Para gerar um relatório com o [FastReport](https://github.com/FastReports/FastReport) é necessário duas partes: um arquivo de design do relatório e um programa para carregar e imputar dados ao relatório.

## Criação do Design

O FastReport possui um software de design que pode ser baixado [aqui](https://github.com/FastReports/FastReport/releases). Mas antes de usar o designer é necessário criar um arquivo de template com o modelo de dados. Para isso é necessário criar um programa que crie o template baseado em um dataset:

```c#
private static void GenerateBaseReport()
{
    var dataSet = new ReportDataSet();

    using (var report = new Report())
    {
        report.RegisterData(dataSet, true);
        report.Save("report-base.frx");
    }
}
```

Após isso é só abrir o template com o software de design e o modelo do dataset estará imputado no arquivo.

Também é possível adicionar manualmente o modelo de dados no xml de um arquivo **.frx**. Para isso comece o arquivo dessa forma:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Report ScriptLanguage="CSharp" ReportInfo.Created="01/17/2020 13:42:06" ReportInfo.Modified="01/17/2020 13:42:06" ReportInfo.CreatorVersion="2019.1.20.0">
  
</Report>
```

E adicione uma tag de dicionário de dados com as informações necessárias ([exemplo](https://github.com/FastReports/FastReport.Documentation/blob/master/ReportTemplateFileStructure.md).

```xml
<?xml version="1.0" encoding="utf-8"?>
<Report ScriptLanguage="CSharp" ReportInfo.Created="01/17/2020 13:42:06" ReportInfo.Modified="01/17/2020 13:42:06" ReportInfo.CreatorVersion="2019.1.20.0">
  <Dictionary>
    <TableDataSource Name="PersonInformation" ReferenceName="Data.PersonInformation" DataType="System.Int32" Enabled="true">
      <Column Name="Name" DataType="System.String"/>
      <Column Name="SkillFinalResult" DataType="System.Decimal"/>
      <Column Name="QualitativeFinalResult" DataType="System.Decimal"/>
      <Column Name="Box" DataType="System.String"/>
      <Column Name="BoxDescription" DataType="System.String"/>
    </TableDataSource>
    <TableDataSource Name="SkillResult" ReferenceName="Data.SkillResult" DataType="System.Int32" Enabled="true">
      <Column Name="PeerResult" Alias="AutoResult" DataType="System.Decimal"/>
      <Column Name="ByLeaderResult" Alias="AutoResult" DataType="System.Decimal"/>
      <Column Name="ToLeaderResult" Alias="AutoResult" DataType="System.Decimal"/>
      <Column Name="WeightedResult" Alias="AutoResult" DataType="System.Decimal"/>
      <Column Name="AutoResult" DataType="System.Decimal"/>
      <Column Name="SkillName" DataType="System.String"/>
    </TableDataSource>
    <TableDataSource Name="OpenQuestions" ReferenceName="Data.OpenQuestions" DataType="System.Int32" Enabled="true">
      <Column Name="Question" DataType="System.String"/>
      <Column Name="Answer" DataType="System.String"/>
    </TableDataSource>
  </Dictionary>
</Report>
```

## Criação do Report

Para a criação do report basta carregar o arquivo de template e passar o DataSet com as informações populadas e mandar gerar o relatório.

```c#
using (var report = new Report())
{
    report.Load("report-designed.frx");
    report.RegisterData(dataset);

    report.Prepare();

    report.SavePrepared($@"prepared-report.fpx");

    var export = new PDFSimpleExport();
    export.Export(report, "report.pdf");
}
```

**O código de um exemplo completo se encontra nesse repositório, basta executar a solução**
