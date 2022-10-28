using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Text.Json;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;
using System.Net;

namespace Roblox_Catalog_Items_Grabber
{
    public partial class Form1 : Form
    {
        bool debugMode = false;
        bool running = false;
        bool cancelled = false;

        String dataFinished = "nil";
        
        String[] accessories = new String[] { //Accessories
            "", //Head
            "", //Face
            "", //Neck
            "", //Shoulder
            "", //Front
            "", //Back
            "", //Waist
        };
        String[] layeredClothing = new String[] { //Layered Clothing
            "", //Sweaters
            "", //Jackets
            "", //Pants
            "", //Shorts
            "", //Dresses & Skirts
            "", //Shoes
            "", //Shirt
            "", //T-Shirt
        };
        String[] body = new String[] { //Body
            "", //Animation Packs
            "", //Bundles
            "", //Hair
            "", //Faces
        };

        public Form1()
        {
            InitializeComponent();
        }

        string filterString(string str)
        {
            char[] allowed = new char[]
            {
                '.',',','/','!','@','#','$','%','^','&','*','(',')',
                '+','-','{','}','[',']',':',';','_','=',' ',
            };

            StringBuilder filtered = new StringBuilder();

            foreach (char c in str)
            {
                bool isValid = false;

                foreach (char c_ in allowed)
                {
                    if (c_ == c)
                    {
                        isValid = true;
                    }
                }

                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'z') || isValid)
                {
                    filtered.Append(c);
                }
            }

            return filtered.ToString();
        }

        void run()
        {
            running = true;

            int currentNumber = 1;
            int currentCategory = 0;
            int currentSubCategory = 0;
            int currentPage = 0;

            int max = accessories.Length + layeredClothing.Length + body.Length;
            bool stalling = false;
            bool finished = false;
            int stallCounter = 0;

            void getAndCompileDataInCategory(int category, int subCategory, int mainList, int slotInList, int designatedNumber)
            {
                while (currentNumber != designatedNumber) { Thread.Sleep(100); }
                
                WebClient client = new WebClient();

                String[] compiled = new String[] { };
                String nextPageCursor = "";

                client.InitializeLifetimeService();

                int runTime = 0;

                void loop() {
                    while (true)
                    {
                        if (cancelled)
                        {
                            break;
                        }

                        try
                        {
                            var json = "";

                            if (nextPageCursor == "")
                            {
                                if (subCategory != 0) {
                                    json = client.DownloadString("https://catalog.roblox.com/v1/search/items/details?Category=" + category as string + "&Subcategory=" + subCategory as string + "&Limit=30");
                                }
                                else
                                {
                                    json = client.DownloadString("https://catalog.roblox.com/v1/search/items/details?Category=" + category as string + "&Limit=30");
                                }
                            }
                            else
                            {
                                if (subCategory != 0)
                                {
                                    json = client.DownloadString("https://catalog.roblox.com/v1/search/items/details?Category=" + category as string + "&Subcategory=" + subCategory as string + "&Limit=30&cursor=" + nextPageCursor);
                                }
                                else
                                {
                                    json = client.DownloadString("https://catalog.roblox.com/v1/search/items/details?Category=" + category as string + "&Limit=30&cursor=" + nextPageCursor);
                                }
                            }

                            currentSubCategory = subCategory;
                            currentPage = runTime;
                            currentCategory = category;

                            dynamic jsonObj = JsonConvert.DeserializeObject(json);

                            if (nextPageCursor != null && nextPageCursor != "")
                            {
                                Console.WriteLine("Reading through page: " + runTime as string + ", Category: " + category as string + ", Sub-Category: " + subCategory as string);
                            }

                            nextPageCursor = jsonObj["nextPageCursor"];

                            String concat = "";

                            for (int i = 0; i < jsonObj["data"].Count; i++)
                            {
                                if (jsonObj["data"][i] != null)
                                {
                                    string name = filterString((String)jsonObj["data"][i]["name"]);
                                    String price = "0";

                                    if ((String)jsonObj["data"][i]["price"] != null)
                                    {
                                        price = (String)jsonObj["data"][i]["price"];
                                    }
                                    else
                                    {
                                        price = "0";
                                    }

                                    concat += "{Name = \"" + name + "\", Id = " + (String)jsonObj["data"][i]["id"] + ", Price = " + price + "}, \n";
                                }
                            }

                            if (mainList == 0)
                            {
                                accessories[slotInList] += concat;
                            }
                            else if (mainList == 1)
                            {
                                layeredClothing[slotInList] += concat;
                            }
                            else if (mainList == 2)
                            {
                                body[slotInList] += concat;
                            }

                            runTime += 1;
                            stalling = false;

                            if (debugMode)
                            {
                                break;
                            }

                            if (nextPageCursor == null)
                            {
                                break;
                            }
                        }
                        catch (WebException e) { stalling = true; }

                        client.Dispose();
                        client.Proxy = null;

                        Thread.Sleep(500);
                    }

                    currentNumber += 1;

                    if (currentNumber > max)
                    {
                        finished = true;
                    }
                }

                loop();
            }

            //Accessories
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 54, 0, 0, 1); }); //Head
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 21, 0, 1, 2); }); //Face
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 22, 0, 2, 3); }); //Neck
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 23, 0, 3, 4); }); //Shoulder
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 24, 0, 4, 5); }); //Front
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 25, 0, 5, 6); }); //Back
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(11, 26, 0, 6, 7); }); //Waist

            //Layered Clothing
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 62, 1, 0, 8); }); //Sweaters
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 61, 1, 1, 9); }); //Jackets
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 60, 1, 2, 10); }); //Pants
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 63, 1, 3, 11); }); //Shorts
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 65, 1, 4, 12); }); //Dresses & Skirts
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 64, 1, 5, 13); }); //Shoes
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 59, 1, 6, 14); }); //Shirts
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(3, 58, 1, 7, 15); }); //T-Shirts

            //Body
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(4, 20, 2, 2, 16); }); //Hair
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(4, 10, 2, 3, 17); }); //Faces
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(17, 0, 2, 1, 18); }); //Bundles
            Task.Factory.StartNew(() => { getAndCompileDataInCategory(12, 38, 2, 0, 19); }); //Animation Bundles
            
            void updateText()
            {
                while (true)
                {
                    if (currentNumber > max)
                    {
                        break;
                    }
                    else
                    {
                        progress_done.Invoke(new MethodInvoker(delegate { progress_done.Text = ("Done: " + currentNumber.ToString() + "/" + max.ToString()); }));
                        progress_running.Invoke(new MethodInvoker(delegate { progress_running.Text = ("Running: Categ: " + currentCategory.ToString() + ", Sub Categ: " + currentSubCategory.ToString() + ", Page: " + currentPage.ToString()); }));
                    }

                    if (stalling)
                    {
                        stallCounter += 1;

                        result_text.Invoke(new MethodInvoker(delegate { result_text.Text = "Stalled " + stallCounter.ToString() + " times"; }));
                    }
                    else
                    {
                        stallCounter = 0;

                        result_text.Invoke(new MethodInvoker(delegate { result_text.Text = "Gathering data."; }));
                    }

                    Thread.Sleep(500);
                }
            }

            Thread updating = new Thread(updateText);
            updating.Start();

            void finishWait()
            {
                while (!finished) { Thread.Sleep(100); }

                //Compile our results.
                dataFinished = @"{
                    ['Accessories'] = {
                        ['Head'] = {
                            " + accessories[0] + @"
                        },

		                ['Face'] = {
                            " + accessories[1] + @"
                        },

		                ['Neck'] = {
                            " + accessories[2] + @"
                        },

		                ['Shoulder'] = {
                            " + accessories[3] + @"
                        },

		                ['Front'] = {
                            " + accessories[4] + @"
                        },

		                ['Back'] = {
                            " + accessories[5] + @"
                        },

		                ['Waist'] = {
                            " + accessories[6] + @"
                        }
                    },

                    ['Body'] = {
                        ['Animation_Packs'] = {
                            " + body[0] + @"
                        },

                        ['Bundles'] = {
                            " + body[1] + @"
                        },

                        ['Hair'] = {
                            " + body[2] + @"
                        },

		                ['Faces'] = {
                            " + body[3] + @"
                        }
                    },
                
		            ['Layered'] = {
			            ['Sweaters'] = {
                            " + layeredClothing[0] + @"
			            },

			            ['Jackets'] = {
                            " + layeredClothing[1] + @"
			            },

			            ['Shorts'] = {
                            " + layeredClothing[3] + @"
			            },

			            ['Dresses_Skirts'] = {
                            " + layeredClothing[4] + @"
			            },

			            ['Shoes'] = {
                            " + layeredClothing[5] + @"
			            },

			            ['T_Shirts'] = {
                            " + layeredClothing[7] + @"
			            },

			            ['Shirts'] = {
                            " + layeredClothing[6] + @"
			            },

			            ['Pants'] = {
                            " + layeredClothing[2] + @"
			            }
	                }
                }";

                running = false;

                result_text.Invoke(new MethodInvoker(delegate { result_text.Text = "Complete, press copy result for a formatted table."; }));
            }

            Thread finish = new Thread(finishWait);
            finish.Start();
        }

        //Check


        //Other buttons
        private void button_run_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                cancelled = false;

                run();
            }
        }

        private void debugMode_box_CheckedChanged(object sender, EventArgs e)
        {
            debugMode = debugMode_box.Checked;
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataFinished);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (running)
            {
                cancelled = true;
            }
        }
    }
}
