using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Final_Project
{
    public class NameAndScore
    {
        public string Name { get; set; }
        public string Score { get; set; }
    }

    public partial class SethsScraper: Form
    {
        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public SethsScraper()
        {
            InitializeComponent();
            InitTable();
        }

        private void InitTable()
        {
            table = new DataTable("MovieRankingsTable");
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Ranking", typeof(string));
            movieRankings.DataSource = table;
        }

        private async Task<List<NameAndScore>> MovieRankingsFromPage ()
        {
            var doc = await Task.Factory.StartNew(() => web.Load("https://www.imdb.com/chart/top?ref_=nv_wl_img_3"));

            var nameNodes = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]//div//span//div//div//div//table//tbody//tr//td//a"); // may have to remove tbody
            var innerNames = nameNodes.Select(node => node.InnerText);
            var names = innerNames.Where((x, i) => (i + 1) % 2 == 0);

            var scoreNodes = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]//div//span//div//div//div//table//tbody//tr//td//strong");
            var scores = scoreNodes.Select(node => node.InnerText);

            return names.Zip(scores, (name, score) => new NameAndScore() { Name = name, Score = score }).ToList();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var rankings = await MovieRankingsFromPage();
            foreach(var ranking in rankings)
            {
                table.Rows.Add(ranking.Name, ranking.Score);
            }
        }
    }
}
