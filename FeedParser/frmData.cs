using System;
using System.Windows.Forms;
using System.Collections.Generic; //List
using System.Collections; //ArrayList
using System.Drawing; //Color
using System.Linq; //Select
using System.Xml.Linq; //XElement & Descendants
using System.Xml.Serialization; //Serialize & Deserialize
using System.Windows.Forms.DataVisualization.Charting; //Charting Tooltips
using System.Web; //HttpUtility
using System.IO; //StreamReader & StreamWriter

namespace FeedParser
{
    public partial class frmData : Form
    {
        private List<Feed> D = new List<Feed>();
        private XmlSerializer x = new XmlSerializer(typeof(List<Feed>));
        private Portfolio portfolio = new Portfolio(100000,0);
        private Feed d;
        public string Symbol { get; set; }

        public frmData()
        {
            InitializeComponent();
        }

        private void frmData_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2500;
            tbInterval.Text = timer1.Interval.ToString();

            chartData.Legends[0].Docking = Docking.Bottom;

            chartData.ChartAreas.Add("data");
            chartData.ChartAreas["data"].AxisX.Minimum = 1;
            chartData.ChartAreas["data"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartData.ChartAreas["data"].AxisX.MajorGrid.Interval = 10;
            chartData.ChartAreas["data"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartData.ChartAreas["data"].CursorX.IsUserEnabled = true;
            chartData.ChartAreas["data"].CursorX.IsUserSelectionEnabled = true;

            chartData.Series.Add("High");
            chartData.Series["High"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartData.Series["High"].Color = Color.Red;

            chartData.Series.Add("Price");
            chartData.Series["Price"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartData.Series["Price"].Color = Color.Green;

            chartData.Series.Add("Low");
            chartData.Series["Low"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartData.Series["Low"].Color = Color.Purple;
        }

        private Feed GetFeed()
        {
            Feed feed = null;

            //http://www.jarloo.com/yahoo_finance/
            string ui = "select * from csv where url='http://download.finance.yahoo.com/d/quotes.csv?s=" +
                Symbol + "&f=sl1d1t1c1ohgv&e=.csv' and columns='symbol,price,date,time,change,open,high,low,volume'";

            try
            {
                Uri uri = new Uri("https://query.yahooapis.com/v1/public/yql?q=" + HttpUtility.UrlEncode(ui));

                XDocument xmlDoc = XDocument.Load(uri.AbsoluteUri);
                XElement elem = (from f in xmlDoc.Descendants("results").Descendants("row") select f).Single();

                DateTime time = Convert.ToDateTime(elem.Element("time").Value);
                DateTime date = Convert.ToDateTime(elem.Element("date").Value);
                
                Decimal price = 0;
                Decimal change = 0;
                Decimal open = 0;
                Decimal high = 0;
                Decimal low = 0;
                Int64 volume = 0;                

                feed = new Feed()
                {
                    Symbol = elem.Element("symbol").Value,
                    Price = (Decimal.TryParse(elem.Element("price").Value, out price)) ? price : 0,
                    Date = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond),
                    Change = (Decimal.TryParse(elem.Element("change").Value, out change)) ? change : 0,
                    Open = (Decimal.TryParse(elem.Element("open").Value, out open)) ? open : 0,
                    High = (Decimal.TryParse(elem.Element("high").Value, out high)) ? high : 0,
                    Low = (Decimal.TryParse(elem.Element("low").Value, out low)) ? low : 0,
                    Volume = (Int64.TryParse(elem.Element("volume").Value, out volume)) ? volume : 0
                };
            }
            catch (Exception)
            {
                feed = new Feed();
            }            

            return feed;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bwGetFeed.IsBusy)
                bwGetFeed.RunWorkerAsync();
        }

        private void cbStartStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = cbStartStop.Checked ? true : false;
        }

        private void tbInterval_TextChanged(object sender, EventArgs e)
        {
            Int32 interval = 0;

            if (Int32.TryParse(tbInterval.Text, out interval) && interval != 0)
                timer1.Interval = interval;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbPrice.Text))
            {
                Decimal price = Decimal.TryParse(tbPrice.Text, out price) ? price : 0;
                Decimal assets = Decimal.TryParse(tbAssets.Text, out assets) ? assets : 0;
                Decimal cash = Decimal.TryParse(tbCash.Text, out cash) ? cash : 0;
                Int64 shares = Int64.TryParse(tbShares.Text, out shares) ? shares : 0;

                //make sure we have enough money to make this transaction
                portfolio.Cash = cash;
                if (portfolio.Cash >= (shares * price))
                {
                    portfolio.Cash -= (shares * price); //subtract spent amount from cash available
                    portfolio.Assets += (shares * price); //add transaction to assets
                    tbCash.Text = portfolio.Cash.ToString(); //display available cash
                    tbAssets.Text = portfolio.Assets.ToString(); //display assets

                    Investment buy = new Investment(Symbol, DateTime.Now, shares, price, price, (shares * price), (shares * price), "BUY");
                    portfolio.Investments.Add(buy);
                    Comparison<Investment> comp = new Comparison<Investment>(Investment.CompareDate);
                    portfolio.Investments.Sort(comp);

                    dgInvestments.DataSource = null;
                    dgInvestments.DataSource = portfolio.Investments;
                }
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Decimal price = Decimal.TryParse(tbPrice.Text, out price) ? price : 0;
            Decimal assets = Decimal.TryParse(tbAssets.Text, out assets) ? assets : 0;
            Decimal cash = Decimal.TryParse(tbCash.Text, out cash) ? cash : 0;
            Int64 shares = Int64.TryParse(tbShares.Text, out shares) ? shares : 0;

            if (dgInvestments.RowCount > 0 && portfolio.Investments[0].Status.Contains("BUY"))
            {
                Investment sold = new Investment(portfolio.Investments[0].Symbol, DateTime.Now, portfolio.Investments[0].Number, portfolio.Investments[0].PricePurchase, portfolio.Investments[0].PriceNow, portfolio.Investments[0].EpsilonPurchase, portfolio.Investments[0].EpsilonNow, "SOLD");

                portfolio.Cash += sold.EpsilonNow; //add liquidated amount to cash available
                portfolio.Assets -= sold.EpsilonNow; //subtract liquidated amount from assets
                tbAssets.Text = portfolio.Assets.ToString(); //display assets
                tbCash.Text = portfolio.Cash.ToString(); //display available cash

                portfolio.Investments.Add(sold);
                Comparison<Investment> comp = new Comparison<Investment>(Investment.CompareDate);
                portfolio.Investments.Sort(comp);

                dgInvestments.DataSource = null;
                dgInvestments.DataSource = portfolio.Investments;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgInvestments.SelectedRows)
            {
                portfolio.Investments.RemoveAt(item.Index);
            }

            dgInvestments.DataSource = null;
            dgInvestments.DataSource = portfolio.Investments;
        }

        private void chartData_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = string.Format("{0:0.####}", dp.YValues[0]);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!bwGetFeed.IsBusy)
            {
                OFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                OFD.Filter = "Feed File (*.feed;)|*.feed;";

                if (OFD.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(OFD.FileName))
                    {
                        D = (List<Feed>)x.Deserialize(sr);

                        Comparison<Feed> comp = new Comparison<Feed>(Feed.CompareVolume);
                        D.Sort(comp); //highest Volume first

                        dgData.DataSource = null;
                        dgData.DataSource = D;

                        chartData.Series["Price"].Points.Clear();
                        chartData.Series["High"].Points.Clear();
                        chartData.Series["Low"].Points.Clear();

                        //need to start from the bottom
                        for (int i = D.Count - 1; i >= 0; i--)
                        {
                            chartData.Series["Price"].Points.Add(new Double[] { (Double)D[i].Price });

                            //add conditions the same as the timer function contains
                            chartData.Series["High"].Points.Add(new Double[] { (Double)D[i].High });
                            chartData.Series["Low"].Points.Add(new Double[] { (Double)D[i].Low });
                        }

                        chartData.ChartAreas["data"].AxisX.Maximum = dgData.RowCount;

                        if (D.Count > 0)
                        {
                            Decimal low = D.Min(l => l.Low);
                            chartData.ChartAreas["data"].AxisY.Minimum = (Double)low - ((Double)low * 0.001);

                            Decimal high = D.Max(h => h.High);
                            chartData.ChartAreas["data"].AxisY.Maximum = (Double)high + ((Double)high * 0.001);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!bwGetFeed.IsBusy)
            {
                SFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                SFD.Filter = "Feed File (*.feed;)|*.feed;";
                SFD.FileName = DateTime.Now.ToShortDateString().Replace('/', '-') + "-" + Symbol;

                if (SFD.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(SFD.FileName))
                    {
                        x.Serialize(sw, D);
                    }
                }
            }
        }

        private void dgData_KeyDown(object sender, KeyEventArgs e)
        {
            //if delete button is pressed then delete selected rows
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow row in dgData.SelectedRows)
                {
                    D.RemoveAt(row.Index);                    
                }

                dgData.DataSource = null;
                dgData.DataSource = D;
            }
        }

        private void bwGetFeed_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            d = null;
            d = GetFeed();
        }

        private void bwGetFeed_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (d.Open != 0 && (d.Date.Year == DateTime.Now.Year && d.Date.Month == DateTime.Now.Month && d.Date.Day == DateTime.Now.Day))
            {
                if (dgData.RowCount == 0)
                {
                    D.Add(d);
                    dgData.DataSource = null;
                    dgData.DataSource = D;

                    chartData.Series["Price"].Points.Clear();
                    chartData.Series["High"].Points.Clear();
                    chartData.Series["Low"].Points.Clear();

                    chartData.Series["Price"].Points.Add(new Double[] { (Double)d.Price });
                    chartData.Series["High"].Points.Add(new Double[] { (Double)d.High });
                    chartData.Series["Low"].Points.Add(new Double[] { (Double)d.Low });

                    chartData.ChartAreas["data"].AxisY.Minimum = (Double)d.Low - ((Double)d.Low * 0.001);
                    chartData.ChartAreas["data"].AxisY.Maximum = (Double)d.High + ((Double)d.High * 0.001);
                }
                else if ((dgData.RowCount >= 1) && (D[0].Price != d.Price) && (D[0].Volume < d.Volume))
                {
                    D.Add(d); //add new item to list
                    Comparison<Feed> comp = new Comparison<Feed>(Feed.CompareVolume);
                    D.Sort(comp); //highest Volume first

                    dgData.DataSource = null;
                    dgData.DataSource = D;

                    chartData.Series["Price"].Points.Add(new Double[] { (Double)d.Price }); //add price

                    Decimal low = D.Min(l => l.Low); //find the lowest value in list
                    Decimal high = D.Max(h => h.High); //find highest value in list

                    //check to see if a new low exists
                    if (d.Low < low)
                        chartData.Series["Low"].Points.Add(new Double[] { (Double)d.Low });
                    else
                        chartData.Series["Low"].Points.Add(new Double[] { (Double)low });

                    //check to see if a new high exists
                    if (d.High > high)
                        chartData.Series["High"].Points.Add(new Double[] { (Double)d.High });
                    else
                        chartData.Series["High"].Points.Add(new Double[] { (Double)high });

                    //set only if Minimum is higher than low
                    if (((Double)d.Low - ((Double)d.Low * 0.001)) < chartData.ChartAreas["data"].AxisY.Minimum)
                        chartData.ChartAreas["data"].AxisY.Minimum = (Double)d.Low - ((Double)d.Low * 0.001);

                    //set only if Maximum is lower than high
                    if (((Double)d.High + ((Double)d.High * 0.001)) > chartData.ChartAreas["data"].AxisY.Maximum)
                        chartData.ChartAreas["data"].AxisY.Maximum = (Double)d.High + ((Double)d.High * 0.001);
                }

                chartData.ChartAreas["data"].AxisX.Maximum = dgData.RowCount;
            }

            if (dgInvestments.RowCount > 0 && portfolio.Investments[0].Status.Contains("BUY"))
            {
                //if we have a transaction AND its a BUY then update Now
                portfolio.Investments[0].PriceNow = d.Price;
                portfolio.Investments[0].EpsilonNow = portfolio.Investments[0].Number * d.Price;
                portfolio.Assets = portfolio.Investments[0].EpsilonNow;
                tbAssets.Text = portfolio.Assets.ToString();

                dgInvestments.DataSource = null;
                dgInvestments.DataSource = portfolio.Investments;
            }
            else if (dgInvestments.RowCount > 0 && portfolio.Investments[0].Status.Contains("SOLD"))
            {
                //TODO: not doing anything with this yet!
                //if we have a transaction AND its a SOLD then update Purchase
                portfolio.Investments[0].PricePurchase = d.Price;
                portfolio.Investments[0].EpsilonPurchase = portfolio.Investments[0].Number * d.Price;

                dgInvestments.DataSource = null;
                dgInvestments.DataSource = portfolio.Investments;
            }
        }                
    }    
}