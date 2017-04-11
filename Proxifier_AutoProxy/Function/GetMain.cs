using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace Proxifier_AutoProxy.Function
{
    public static class GetMain
    {
        public static string ipresult;
        public static string dns_proxy;
        public static string dns_direct;
        public static string def_ppt_base64 = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pgo8UHJveGlmaWVyUHJvZmlsZSB2ZXJzaW9uPSIxMDIiIHBsYXRmb3JtPSJXaW5kb3dzIiBwcm9kdWN0X2lkPSIwIiBwcm9kdWN0X21pbnZlcj0iMzEwIj4KICA8T3B0aW9ucz4KICAgIDxSZXNvbHZlPgogICAgICA8QXV0b01vZGVEZXRlY3Rpb24gZW5hYmxlZD0iZmFsc2UiIC8+CiAgICAgIDxWaWFQcm94eSBlbmFibGVkPSJ0cnVlIj4KICAgICAgICA8VHJ5TG9jYWxEbnNGaXJzdCBlbmFibGVkPSJmYWxzZSIgLz4KICAgICAgPC9WaWFQcm94eT4KICAgICAgPEV4Y2x1c2lvbkxpc3QgT25seUZyb21MaXN0TW9kZT0idHJ1ZSI+KnByb3h5LWRucy1ob3N0KjwvRXhjbHVzaW9uTGlzdD4KICAgIDwvUmVzb2x2ZT4KICAgIDxFbmNyeXB0aW9uIG1vZGU9ImRpc2FibGVkIiAvPgogICAgPEh0dHBQcm94aWVzU3VwcG9ydCBlbmFibGVkPSJmYWxzZSIgLz4KICAgIDxIYW5kbGVEaXJlY3RDb25uZWN0aW9ucyBlbmFibGVkPSJmYWxzZSIgLz4KICAgIDxDb25uZWN0aW9uTG9vcERldGVjdGlvbiBlbmFibGVkPSJ0cnVlIiAvPgogICAgPFByb2Nlc3NTZXJ2aWNlcyBlbmFibGVkPSJmYWxzZSIgLz4KICAgIDxQcm9jZXNzT3RoZXJVc2VycyBlbmFibGVkPSJmYWxzZSIgLz4KICA8L09wdGlvbnM+CiAgPFByb3h5TGlzdD4KICAgIDxQcm94eSBpZD0iMTAwIiB0eXBlPSJTT0NLUzUiPgogICAgICA8QWRkcmVzcz4xMjcuMC4wLjE8L0FkZHJlc3M+CiAgICAgIDxQb3J0PjEwODA8L1BvcnQ+CiAgICAgIDxPcHRpb25zPjQ4PC9PcHRpb25zPgogICAgPC9Qcm94eT4KICA8L1Byb3h5TGlzdD4KICA8Q2hhaW5MaXN0IC8+CiAgPFJ1bGVMaXN0PgogICAgPFJ1bGUgZW5hYmxlZD0idHJ1ZSI+CiAgICAgIDxOYW1lPlNoYWRvd3NvY2tzPC9OYW1lPgogICAgICA8QXBwbGljYXRpb25zPnNoYWRvd3NvY2tzLmV4ZTwvQXBwbGljYXRpb25zPgogICAgICA8QWN0aW9uIHR5cGU9IkRpcmVjdCIgLz4KICAgIDwvUnVsZT4KICAgIDxSdWxlIGVuYWJsZWQ9InRydWUiPgogICAgICA8TmFtZT5Mb2NhbGhvc3Q8L05hbWU+CiAgICAgIDxUYXJnZXRzPmxvY2FsaG9zdDsgMTI3LjAuMC4xOyAlQ29tcHV0ZXJOYW1lJTsxMC4wLjAuMC0xMC4yNTUuMjU1LjI1NTsgMTcyLjE2LjAuMC0xNzIuMzEuMjU1LjI1NTsxOTIuMTY4LjAuMC0xOTIuMTY4LjI1NS4yNTUgPC9UYXJnZXRzPgogICAgICA8QWN0aW9uIHR5cGU9IkRpcmVjdCIgLz4KICAgIDwvUnVsZT4KICAgIDxSdWxlIGVuYWJsZWQ9InRydWUiPgogICAgICA8TmFtZT5DaGluYS1JUDwvTmFtZT4KICAgICAgPFRhcmdldHM+Q2hpbmEtSVA8L1RhcmdldHM+CiAgICAgIDxBY3Rpb24gdHlwZT0iRGlyZWN0IiAvPgogICAgPC9SdWxlPgogICAgPFJ1bGUgZW5hYmxlZD0idHJ1ZSI+CiAgICAgIDxOYW1lPkNoaW5hLUhvc3Q8L05hbWU+CiAgICAgIDxUYXJnZXRzPkNoaW5hLUhvc3Q8L1RhcmdldHM+CiAgICAgIDxBY3Rpb24gdHlwZT0iRGlyZWN0IiAvPgogICAgPC9SdWxlPgogICAgPFJ1bGUgZW5hYmxlZD0idHJ1ZSI+CiAgICAgIDxOYW1lPlByb2V4eS1Ib3N0PC9OYW1lPgogICAgICA8VGFyZ2V0cz5Qcm9leHktSG9zdDwvVGFyZ2V0cz4KICAgICAgPEFjdGlvbiB0eXBlPSJQcm94eSI+MTAwPC9BY3Rpb24+CiAgICA8L1J1bGU+CiAgICA8UnVsZSBlbmFibGVkPSJ0cnVlIj4KICAgICAgPE5hbWU+RGVmYXVsdDwvTmFtZT4KICAgICAgPEFjdGlvbiB0eXBlPSJQcm94eSI+MTAwPC9BY3Rpb24+CiAgICA8L1J1bGU+CiAgPC9SdWxlTGlzdD4KPC9Qcm94aWZpZXJQcm9maWxlPg==";
        public static void Get_IP(string url, string country)
        {
            Forms.MainForm.progressbar_int = 10;
            //Web
            Forms.MainForm.tip = "Download...";
            string Url = url, Country = country;
            HttpClient hc = new HttpClient();
            string wenrp = hc.GetStringAsync(url).Result;
            Forms.MainForm.tip = "Download Success,Analysising...";
            Forms.MainForm.progressbar_int = 50;
            //GetIp
            string[] str_rawlines = wenrp.Split(new string[] { "\n" }, StringSplitOptions.None);
            string ips = string.Empty;
            int max_num = str_rawlines.Count();
            int now_num = 0;
            int total_num = 0;
            foreach (string rawline in str_rawlines)
            {
                string[] linedate = rawline.Split('|');
                if (linedate.Count() == 7)
                {
                    if (linedate[1] == Country & linedate[2] == "ipv4")
                    {
                        string beginip = linedate[3];
                        //GetEndIp
                        string ip_binary = string.Empty;
                        int i_i = 0;
                        foreach (string i in beginip.Split('.'))
                        {
                            string binary = Convert.ToString(Convert.ToInt32(i), 2);
                            if (binary.Count() != 8)
                            {
                                string add_bin = string.Empty;
                                for (int i_b = 0; i_b < 8 - binary.Count(); i_b++)
                                {
                                    add_bin += "0";
                                }
                                ip_binary += (add_bin + binary);
                            }
                            else
                            {
                                ip_binary += binary;
                            }
                            // System.Console.WriteLine(ip_binary);
                            i_i++;
                        }
                        var bin_count = (int)System.Math.Log(Convert.ToInt32(linedate[4]), 2);
                        string full_bin = string.Empty;
                        for (int i_a = 0; i_a < bin_count; i_a++)
                        {
                            full_bin += "1";
                        }
                        string endip_bin = ip_binary.Substring(0, 32 - bin_count) + full_bin;
                        string endip = System.Convert.ToInt32(endip_bin.Substring(0, 8), 2).ToString() + "." + System.Convert.ToInt32(endip_bin.Substring(8, 8), 2).ToString() + "." + System.Convert.ToInt32(endip_bin.Substring(16, 8), 2).ToString() + "." + System.Convert.ToInt32(endip_bin.Substring(24, 8), 2).ToString();
                        ips += beginip + "-" + endip + ";";
                        // System.Console.WriteLine(endip);
                        // System.Console.WriteLine(rawline);
                        total_num += Convert.ToInt32(linedate[4]);
                    }

                }
                now_num = now_num + 1;
                Forms.MainForm.tip = now_num.ToString() + "/" + max_num.ToString();
            }
            Forms.MainForm.progressbar_int = 60;
            Forms.MainForm.tip = "Total:" + total_num;
            ipresult = string.Empty;
            ipresult = ips;
            //return ips;
        }

        public static void GetDns_Whitelist(string gfwlist_url)
        {
            Forms.MainForm.tip = "Download...GFWList";
            HttpClient hc = new HttpClient();
            string wenrp = hc.GetStringAsync(gfwlist_url).Result;
            Forms.MainForm.tip = "Download GFWList Success,Analysising...";
            Forms.MainForm.progressbar_int = 80;
            string gfwlist = Encoding.UTF8.GetString(Convert.FromBase64String(wenrp));
            dns_direct = string.Empty;
            dns_proxy = string.Empty;
            foreach (string line in gfwlist.Split(new string[] { "\n" }, StringSplitOptions.None))
            {
                //check
                if (Regex.IsMatch(line, "^\\[.*\\]$") || Regex.IsMatch(line, "^!") || line == string.Empty)
                {
                    //System.Console.WriteLine(lint);
                    continue;
                }
                //
                if (Regex.IsMatch(line, "^\\|\\|(.*)"))
                {
                    var date = Regex.Match(line, "^\\|\\|(?<url>\\S+)").Groups["url"].Value;
                    foreach (char c in "=!@#$%^&() _+{}|:<>?~`[]\\;',/")
                    {
                        date = date.Replace(c, '*');
                    }
                    dns_proxy += " *" + date + "*;";
                    continue;
                }
                else if (Regex.IsMatch(line, "^@@\\|\\|(.*)"))
                {
                    var date = Regex.Match(line, "^@@\\|\\|(?<url>\\S+)").Groups["url"].Value;
                    foreach (char c in "=!@#$%^&() _+{}|:<>?~`[]\\;',/")
                    {
                        date = date.Replace(c, '*');
                    }
                    dns_direct += " *" + date + "*;";
                    continue;
                }
                else if (Regex.IsMatch(line, "^([^@|].*)"))
                {
                    //System.Console.WriteLine(line);
                    if (Regex.IsMatch(line, "^\\.(.*)"))
                    {
                        var date = line;
                        foreach (char c in "=!@#$%^&() _+{}|:<>?~`[]\\;',/")
                        {
                            date = date.Replace(c, '*');
                        }
                        dns_proxy += " *" + date + "*;";
                    }
                    else if (!Regex.IsMatch(line, "^/\\^(.*)"))
                    {
                        var date = line;
                        foreach (char c in "=!@#$%^&() _+{}|:<>?~`[]\\;',/")
                        {
                            date = date.Replace(c, '*');
                        }
                        dns_proxy += " *" + date + "*;";
                    }

                }
            }
            Forms.MainForm.progressbar_int = 100;
            Forms.MainForm.tip = "OK.";
            //System.Console.WriteLine(dns_proxy);
            //System.Console.WriteLine(dns_direct);
        }
    }
}
