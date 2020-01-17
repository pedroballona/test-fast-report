using FastReport;
using FastReport.Export.PdfSimple;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ReportPOC
{
  internal class Program
  {

    private static void Main(string[] _)
    {
      GenerateBaseReport();
      GenerateReportFromData();
    }

    private static void GenerateBaseReport()
    {
      var dataSet = new ReportDataSet();

      using (var report = new Report())
      {
        report.RegisterData(dataSet, true);
        report.Save("report-base.frx");
      }
    }

    private static void GenerateReportFromData()
    {
      var dataset = new ReportDataSet();

      {
        DataTable personInformation = dataset.Tables["PersonInformation"];
        DataRow row = personInformation.NewRow();
        row["Name"] = "Arlindo Cruz";
        row["SkillFinalResult"] = 3.4534445M;
        row["QualitativeFinalResult"] = 2.123334M;
        row["Box"] = "3A";
        row["BoxDescription"] =
          @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Arcu felis bibendum ut tristique et egestas quis ipsum. Amet justo donec enim diam vulputate ut. A cras semper auctor neque vitae tempus. Elementum integer enim neque volutpat ac tincidunt vitae semper quis. Netus et malesuada fames ac turpis egestas. Scelerisque purus semper eget duis at tellus. Tortor vitae purus faucibus ornare suspendisse sed nisi. Eget felis eget nunc lobortis mattis aliquam. Mi in nulla posuere sollicitudin aliquam. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Accumsan lacus vel facilisis volutpat est velit egestas. Vel quam elementum pulvinar etiam non quam lacus suspendisse.";
        personInformation.Rows.Add(row);
      }

      {
        DataTable skillResult = dataset.Tables["SkillResult"];
        (string skillName, decimal auto, decimal peer, decimal byLeader, decimal toLeader, decimal total)[] skill = new[]
        {
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M),
          (skillName: "Competência em Resolver Desafios", auto: 1M, peer: 2M, byLeader: 3M, toLeader: 4M, total: 5M)
        };
        foreach ((string skillName, decimal auto, decimal peer, decimal byLeader, decimal toLeader, decimal total) tuple in skill)
        {
          DataRow row = skillResult.NewRow();
          row["SkillName"] = tuple.skillName;
          row["PeerResult"] = tuple.peer;
          row["ByLeaderResult"] = tuple.byLeader;
          row["ToLeaderResult"] = tuple.toLeader;
          row["WeightedResult"] = tuple.total;
          row["AutoResult"] = tuple.auto;
          skillResult.Rows.Add(row);
        }
      }

      {
        DataTable openQuestions = dataset.Tables["OpenQuestions"];

        (string question, string answer)[] data = new[]
        {
          (question: "Dê três pontos positivos", answer: @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Arcu felis bibendum ut tristique et egestas quis ipsum. Amet justo donec enim diam vulputate ut. A cras semper auctor neque vitae tempus. Elementum integer enim neque volutpat ac tincidunt vitae semper quis. Netus et malesuada fames ac turpis egestas. Scelerisque purus semper eget duis at tellus. Tortor vitae purus faucibus ornare suspendisse sed nisi. Eget felis eget nunc lobortis mattis aliquam. Mi in nulla posuere sollicitudin aliquam. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Accumsan lacus vel facilisis volutpat est velit egestas. Vel quam elementum pulvinar etiam non quam lacus suspendisse.

          Praesent elementum facilisis leo vel fringilla est ullamcorper eget. Convallis a cras semper auctor neque vitae tempus quam. Tortor pretium viverra suspendisse potenti nullam ac tortor vitae. Ut enim blandit volutpat maecenas volutpat blandit aliquam etiam. Tortor consequat id porta nibh venenatis cras sed felis. Imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis. Donec adipiscing tristique risus nec feugiat in fermentum posuere. In mollis nunc sed id semper risus. Vulputate eu scelerisque felis imperdiet. Egestas dui id ornare arcu odio ut sem nulla pharetra. Est ultricies integer quis auctor elit sed vulputate mi sit. Odio tempor orci dapibus ultrices. Egestas erat imperdiet sed euismod nisi porta lorem mollis. Urna et pharetra pharetra massa massa ultricies mi."),

          (question: "Dê três pontos negativos", answer: @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Arcu felis bibendum ut tristique et egestas quis ipsum. Amet justo donec enim diam vulputate ut. A cras semper auctor neque vitae tempus. Elementum integer enim neque volutpat ac tincidunt vitae semper quis. Netus et malesuada fames ac turpis egestas. Scelerisque purus semper eget duis at tellus. Tortor vitae purus faucibus ornare suspendisse sed nisi. Eget felis eget nunc lobortis mattis aliquam. Mi in nulla posuere sollicitudin aliquam. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Accumsan lacus vel facilisis volutpat est velit egestas. Vel quam elementum pulvinar etiam non quam lacus suspendisse.

          Praesent elementum facilisis leo vel fringilla est ullamcorper eget. Convallis a cras semper auctor neque vitae tempus quam. Tortor pretium viverra suspendisse potenti nullam ac tortor vitae. Ut enim blandit volutpat maecenas volutpat blandit aliquam etiam. Tortor consequat id porta nibh venenatis cras sed felis. Imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis. Donec adipiscing tristique risus nec feugiat in fermentum posuere. In mollis nunc sed id semper risus. Vulputate eu scelerisque felis imperdiet. Egestas dui id ornare arcu odio ut sem nulla pharetra. Est ultricies integer quis auctor elit sed vulputate mi sit. Odio tempor orci dapibus ultrices. Egestas erat imperdiet sed euismod nisi porta lorem mollis. Urna et pharetra pharetra massa massa ultricies mi.")
        };

        foreach ((string question, string answer) tuple in data)
        {
          DataRow row = openQuestions.NewRow();
          row["Question"] = tuple.question;
          row["Answer"] = tuple.answer;
          openQuestions.Rows.Add(row);
        }

      }

      using (var report = new Report())
      {
        report.Load("report-designed.frx");
        report.RegisterData(dataset);

        report.Prepare();

        report.SavePrepared($@"prepared-report.fpx");

        var export = new PDFSimpleExport();
        export.Export(report, "report.pdf");
        var fullPath = Path.GetFullPath("report.pdf");
        new Process
        {
          StartInfo = new ProcessStartInfo(fullPath)
          {
            UseShellExecute = true
          }
        }.Start();
      }
    }
  }
}
