using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;

namespace GetResult
{

    public struct TClientInfo
    {
        public string name;
        public string no;
        public string id;
        public string result;
        public string cnt;
        public int index;
        public Boolean valid; 
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public Dictionary<string, TClientInfo> infos = new Dictionary<string, TClientInfo>(); 

        TestCookie sc = new TestCookie();

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = doGetImg("http://www.alltobid.com/GPCarQuery.Web/Image/ValiCode?r=0.9712236050982028", sc);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string poststr = "MobileConfirmNumber=&Type=2&BidderNo=52314538&IDCard=0528&picValidCode=" + textBox1.Text + "&mvc_command=&mvc_args=";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(poststr);
            String s = doPost("http://www.alltobid.com/GPCarQuery.Web/Home/Query/", data, sc, "utf-8", "http://www.alltobid.com/GPCarQuery.Web/Home/Personal");
            char[] cc = new char[1];
            cc[0] = '\r';
            string[] ss = s.Split(cc);
            Console.Out.WriteLine(ss[23]); //<p><font color="red" size="+2">杨莹,您没有成交。</font></p>
            Console.Out.WriteLine(ss[33]); //           <td >6</td>
        }

        public static string doPost(string Url, byte[] postData, TestCookie bCookie, String encodingFormat, String referer)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url.ToString());
                myRequest.CookieContainer = bCookie.mycookie;
                myRequest.Method = "POST";
                myRequest.Timeout = 30000;
                myRequest.KeepAlive = true;
                if (referer != "")
                    myRequest.Referer = referer;
                myRequest.Headers["Cache-control"] = "no-cache";
                myRequest.Headers["Accept-Language"] = "zh-cn";
                myRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Trident/4.0; GTB7.4; GTB7.1; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.2)";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.Accept = "*/*";
                myRequest.ContentLength = postData.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postData, 0, postData.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                bCookie.upcookie(myResponse.Cookies);
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(encodingFormat));
                string outdata = reader.ReadToEnd();
                reader.Close();
                if (!outdata.Contains("基础连接已经关闭: 连接被意外关闭") && !outdata.Contains("无法连接到远程服务器") && !outdata.Contains("基础连接已经关闭: 接收时发生错误。"))
                    return outdata;
                else
                    return "基础连接已经关闭: 连接被意外关闭";
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("基础连接已经关闭: 连接被意外关闭") && !ex.Message.Contains("无法连接到远程服务器") && !ex.Message.Contains("基础连接已经关闭: 接收时发生错误。"))
                    return ex.Message;
                else
                    return "基础连接已经关闭: 连接被意外关闭";
            }
        }

        public static string doGet(string Url, byte[] postData, TestCookie bCookie, String encodingFormat, String referer)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url.ToString());
                myRequest.CookieContainer = bCookie.mycookie;
                myRequest.Method = "GET";
                myRequest.Timeout = 30000;
                myRequest.KeepAlive = true;
                if (referer != "")
                    myRequest.Referer = referer;
                //                xmlhttp.setRequestHeader("If-Modified-Since", "0");
                // xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                myRequest.Headers["Cache-control"] = "no-cache";
                myRequest.Headers["Accept-Language"] = "zh-cn";
                myRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Trident/4.0; GTB7.4; GTB7.1; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.2)";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.Accept = "*/*";
                /*
                myRequest.ContentLength = postData.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postData, 0, postData.Length);
                newStream.Close();
                 * 
                 * */
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                bCookie.upcookie(myResponse.Cookies);
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding(encodingFormat));
                string outdata = reader.ReadToEnd();
                reader.Close();
                if (!outdata.Contains("基础连接已经关闭: 连接被意外关闭") && !outdata.Contains("无法连接到远程服务器") && !outdata.Contains("基础连接已经关闭: 接收时发生错误。"))
                    return outdata;
                else
                    return "基础连接已经关闭: 连接被意外关闭";
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("基础连接已经关闭: 连接被意外关闭") && !ex.Message.Contains("无法连接到远程服务器") && !ex.Message.Contains("基础连接已经关闭: 接收时发生错误。"))
                    return ex.Message;
                else
                    return "基础连接已经关闭: 连接被意外关闭";
            }
        }

        public static Image doGetImg(string Url, TestCookie bCookie)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url.ToString());
                myRequest.ServicePoint.Expect100Continue = true;
                myRequest.CookieContainer = bCookie.mycookie;
                myRequest.Method = "GET";
                myRequest.Timeout = 30000;
                myRequest.KeepAlive = true;//modify by yang
                myRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Trident/4.0; GTB7.4; GTB7.1; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.2)";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                bCookie.upcookie(myResponse.Cookies);

                return Bitmap.FromStream(myResponse.GetResponseStream());
            }
            catch
            {
                return null;
            }
        }

        public class TestCookie
        {
            public CookieContainer mycookie = new CookieContainer();//定义cookie容器
            public Object obj = new Object();
            public byte[] byt = new byte[1];
            public void upcookie(CookieCollection cookie)
            {
                for (int i = 0; i < cookie.Count; i++)
                {
                    mycookie.Add(cookie[i]);
                }
                obj = mycookie;
                byt = ObjectToBytes(obj);
            }
            /**/
            /// <summary>
            /// 将一个object对象序列化，返回一个byte[]
            /// </summary>
            /// <param name="obj">能序列化的对象</param>
            /// <returns></returns>
            public static byte[] ObjectToBytes(object obj)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    return ms.GetBuffer();
                }
            }

            /**/
            /// <summary>
            /// 将一个序列化后的byte[]数组还原
            /// </summary>
            /// <param name="Bytes"></param>
            /// <returns></returns>
            public object BytesToObject(byte[] Bytes)
            {
                using (MemoryStream ms = new MemoryStream(Bytes))
                {
                    IFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(ms);
                }
            }
            public CookieContainer getcookie()
            {
                return mycookie;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLibFromFile("alltobid.lib", "123");
        }

        [DllImport("Sunday.dll", EntryPoint = "LoadLibFromFile")]
        static extern int LoadLibFromFile(string CdsFile, string password);

        [DllImport("Sunday.dll", EntryPoint = "GetCodeFromBuffer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        static extern Boolean GetCodeFromBuffer(int CdsFileIndex, byte[] ImgBuffer, int ImgBufLen, StringBuilder Vcode);


        private String getRandom()
        {
            int iSeed = 6;
            Random ra = new Random(iSeed);
            return "0." + Convert.ToString(ra.Next(100000, 200000)) + Convert.ToString(ra.Next(300000, 400000));
        }

        //http://www.alltobid.com/gpcarquery.web/home/personal
        private void QueryResult(Object info)
        {
            TClientInfo inf = (TClientInfo)info;
            String cresult = "";
            while (cresult.Equals(""))
            {
                TestCookie sc0 = new TestCookie();
                Image image = null;
                while (image == null)
                {
                    try
                    {
                        image = doGetImg("http://www.alltobid.com/GPCarQuery.Web/Image/ValiCode?r=" + getRandom(), sc0);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                StringBuilder s = new StringBuilder('\0', 256);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] bytes = ms.GetBuffer();
                String scode = "";
                try
                {
                    GetCodeFromBuffer(1, bytes, bytes.Length, s);
                    scode = s.ToString();
                    if (scode.Trim().Equals(""))
                        continue;
                }
                catch (Exception ex)
                {
                }

                //string poststr = "MobileConfirmNumber=&Type=2&BidderNo=" + inf.no + "&IDCard=" + inf.id + "&picValidCode=" + scode + "&mvc_command=&mvc_args=";
                //新的get数据
                //http://www.alltobid.com/GPCarQuery.Web/Home/Query?idcard=1445&number=52511735&type=2&nc=0.9940528327133507&code=8177
                string getstr = "http://www.alltobid.com/GPCarQuery.Web/Home/Query?idcard=" + inf.id + "&number=" + inf.no + "&type=2&nc=" + getRandom() + "&code=" + scode;
                byte[] data = System.Text.Encoding.UTF8.GetBytes(getstr);
                String queryresult = ":验证码错误";
                try
                {
                    queryresult = doGet(getstr, data, sc0, "utf-8", "http://www.alltobid.com/gpcarquery.web/home/personal");
                }
                catch (Exception ex)
                {
                }
               // if ( (queryresult.IndexOf("验证码错误") >= 0) || (queryresult.IndexOf("\"ClientName\":null") >= 0) )
                 if (queryresult.IndexOf("验证码错误") >= 0)
                {
                    //验证码错误，重新请求
                    Thread.Sleep(5);
                }
                else
                {
                    textBox9.Text += queryresult + "\r\n";
                    // 未成 成 无效
                    //{"ClientName":"蒋雯怡","AucTime":"","validdate":"2015-04-30","used":2,"NeedPay":0,"code":0,"err":null,"publishtime":"2014-11-15"}
                    //{"ClientName":"薛旦","AucTime":"2014-11-15 11:29:59","validdate":"2015-01-31","used":5,"NeedPay":1,"code":0,"err":null,"publishtime":"2014-11-15"}
                    //{"ClientName":null,"AucTime":null,"validdate":null,"used":0,"NeedPay":0,"code":2,"err":null,"publishtime":null}
                    cresult = "success";

                    if (queryresult.IndexOf("\"ClientName\":null") >= 0)
                    {
                        inf.result = "可能已失效";
                    }
                    else
                    {
                        inf.cnt = "未知";
                        if (queryresult.IndexOf("\"used\":") >= 0)
                        {
                            try
                            {
                                String sused = queryresult.Substring(queryresult.IndexOf("\"used\":") + 7, 1);
                                int used = Convert.ToInt16(sused);
                                inf.cnt = Convert.ToString(6 - used);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        int ifound = queryresult.IndexOf("\"NeedPay\":0");
                        if (ifound >= 0)
                        {
                            inf.result = "未成交";
                        }
                        else
                        {
                            inf.result = "成交";
                        }
                    }
              
                }
            }
            ListViewItem li = lv.Items[inf.index];
            li.BackColor = Color.White;
            if (inf.result.Equals("成交"))
                li.ForeColor = Color.Black;
            li.SubItems.Add(inf.result);
            li.SubItems.Add(inf.cnt);
            /*
            char[] cc = new char[1];
            cc[0] = '\r';
            string[] ss = queryresult.Split(cc);
            Console.Out.WriteLine(ss[23]); //<p><font color="red" size="+2">杨莹,您没有成交。</font></p>
            Console.Out.WriteLine(ss[33]); //           <td >6</td>
            Console.Out.WriteLine(inf.cnt);
            String s = "";
            if (s.IndexOf("alert('验证码不正确')") >= 0)
            {
            }
            
            TClientInfo inf = (TClientInfo)info;
            //DispMsg(0, inf.name);
            ListViewItem li = lv.Items[inf.index];
            li.SubItems.Add("a");
            li.SubItems.Add("b");
             */
        }

        private delegate void DispMSGDelegate(int iIndex, string strMsg);

        private void DispMsg(int iIndex,string strMsg)
        {
            if (lv.InvokeRequired)
            {
                DispMSGDelegate DMSGD = new DispMSGDelegate(DispMsg);
                this.lv.Invoke(DMSGD, iIndex, strMsg);
            }
            else
            {
                ListViewItem li = lv.Items[iIndex];
                li.SubItems[0].Text = "a";
                li.SubItems[1].Text = "b";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            infos.Clear();
            lv.Items.Clear();
            string[] nos = textBox7.Lines;
            string[] ids = textBox8.Lines;
            int j = 0;
            for (int i = 0; i < nos.Length; i++)
            {
                if (nos[i].Trim().Length != 8)
                    continue;
                TClientInfo info = new TClientInfo();
                info.name = nos[i].Trim();
                info.no = nos[i].Trim();
                if (i >= ids.Length)
                    info.id = "0000";
                else
                    info.id = ids[i].Trim();
                info.index = j;
                j++;
                if ( (info.name.Length == 8) && (!infos.ContainsKey(info.name)) && (!info.id.Equals("0000")) && (info.id.Length == 4) )
                {
                    infos.Add(info.name, info);
                    ListViewItem li = new ListViewItem();
                    li.Text = Convert.ToString(info.index+1);
                    li.BackColor = Color.Aqua;
                    li.ForeColor = Color.Red;
                    li.SubItems.Add(info.name);
                    lv.Items.Add(li);
                }
            }
            /*
            int j = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                String s = listBox1.Items[i].ToString();
                s = s.Replace("\t\t","\t");
                s = s.Replace("\t\t", "\t");
                s = s.Replace("\t\t", "\t");
                String[] ss = s.Split('\t');
                if (ss.Length >= 4)
                {
                    TClientInfo info = new TClientInfo();
                    info.name = ss[0];
                    info.no = ss[1];
                    info.id = ss[3];
                    info.index = j;
                    j++;
                    if (!infos.ContainsKey(info.name))
                    {
                        infos.Add(info.name, info);
                        ListViewItem li = new ListViewItem();
                        li.Text = info.name;
                        li.BackColor = Color.Aqua;
                        li.ForeColor = Color.Red;
                        lv.Items.Add(li);                       
                    }
                }
            }
            */
            this.Update();
            foreach (TClientInfo _info in infos.Values)
            {
                Thread t = new Thread(new ParameterizedThreadStart(QueryResult));
                t.Start(_info);
            }
            /*
            for (int i = 0; i < 1; i++)
            {
                TClientInfo info = new TClientInfo();
                info.no = "52314538";
                info.id = "0528";
                info.cnt = Convert.ToString(i);
                Thread t = new Thread(new ParameterizedThreadStart(QueryResult));
                t.Start(info);
            }
            */
            /*
            LoadLibFromFile("alltobid.lib", "123");
            MemoryStream   ms   =   new   MemoryStream(); 
            pictureBox1.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Bmp); 
            byte[]   bytes=   ms.GetBuffer();
            StringBuilder s = new StringBuilder('\0', 256);
            try
            {
                GetCodeFromBuffer(1, bytes, bytes.Length, s);
            }
            catch (Exception ex)
            {
            }
            textBox1.Text = s.ToString();
            */
            /*
            Bitmap bitmap = (Bitmap)pictureBox1.Image;
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();//声明一个OCR类
            ocr.SetVariable("tessedit_char_whitelist", "0123456789"); //设置识别变量，当前只能识别数字。
            ocr.Init(Application.StartupPath + @"\\tessdata", "eng", true);
            List<tessnet2.Word> result = ocr.DoOCR(bitmap, Rectangle.Empty);//执行识别操作
            string code = result[0].Text;
            textBox1.Text = code;
            */
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "c:\\temp\\10个标书.txt";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            listBox1.Items.Clear();
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);

            StreamReader m_streamReader = new StreamReader(fs, Encoding.GetEncoding("GBK"));

            m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string strLine = m_streamReader.ReadLine();
            do
            {
                strLine = strLine.Trim();
                if (!strLine.Equals(""))
                    listBox1.Items.Add(strLine);
                strLine = m_streamReader.ReadLine();

            } while (strLine != null);
            m_streamReader.Close();
            m_streamReader.Dispose();
            fs.Close();
            fs.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String text = "";
                for (int i = 0; i < lv.Items.Count; i++)
                    text += lv.Items[i].Text + "\t" + lv.Items[i].SubItems[1].Text + "\t" + lv.Items[i].SubItems[2].Text + "\r\n";
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding("GBK"));
                sw.Write(text);
                sw.Close();
            }
            */
            /*
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("至少选择一项导出项目");
                return;
            }
            */
            if (true)
            {
                String text = "";
                for (int i = 0; i < lv.Items.Count; i++)
                    if (lv.Items[i].SubItems[2].Text.Equals("成交"))
                        text += lv.Items[i].SubItems[1].Text + "\r\n";
                StreamWriter sw = new StreamWriter(Application.StartupPath+@"\成交.txt", false, Encoding.GetEncoding("GBK"));
                sw.Write(text);
                sw.Close();
            }
            if (checkBox2.Checked)
            {
                String text = "";
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    try
                    {
                        if (lv.Items[i].SubItems[3].Text.Equals("0"))
                            text += lv.Items[i].SubItems[1].Text + "\r\n";
                    }
                    catch (Exception ex)
                    {
                    }
                }
                StreamWriter sw = new StreamWriter(Application.StartupPath + @"\过期.txt", false, Encoding.GetEncoding("GBK"));
                sw.Write(text);
                sw.Close();
            }
            MessageBox.Show("已导出");
        }
    }
}
