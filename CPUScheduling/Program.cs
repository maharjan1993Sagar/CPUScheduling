using System;
using System.Linq;

namespace CPUScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            cpuschedule schedule = new cpuschedule();
            schedule.Getdata();
        }
    }
    public class cpuschedule //https://www.geeksforgeeks.org/gate-notes-operating-system-process-scheduling/
    {
        //ArrayList al = new ArrayList();//for dynamic arraylist of variable size array
        public int n;
        public int[] Bu;
        public int[] B;
        public float Twt, Awt, w;
        public int[] A;
        public float[] tat;
        public float[] Wt;
        public int[] p;
        public int q;
        public string att;
        public string awt;


        public void Exit()
        {
            Console.WriteLine("Choice.\n1.Re-Start\n2.End");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Getdata();
                        break;
                    }
                case 2:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public void Getdata()
        {
            //For Fcfs
            Console.WriteLine("Choose from 1-6.\n1.FCFS\n2.SJF\n3.Priority\n4.RR\n5.Weighted RR\n6.RR with variable quanta");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        tat = new float[n];
                        A = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time and arrival time seperated by ',' for Process P{0}", i + 1);
                            string getstr = Console.ReadLine();
                            B[i] = Int32.Parse(getstr.Split(',').First());
                            A[i] = Int32.Parse(getstr.Split(',').Last());
                        }
                        Fcfs();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        tat = new float[n];
                        A = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time and arrival time seperated by ',' for Process P{0}", i + 1);
                            string getstr = Console.ReadLine();
                            B[i] = Int32.Parse(getstr.Split(',').First());
                            A[i] = Int32.Parse(getstr.Split(',').Last());
                        }
                        Sjf();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        p = new int[n];
                        tat = new float[n];
                        A = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time and priority arrival time for Process P{0} seperated by ','", i + 1);
                            string str = Console.ReadLine();
                            B[i] = Int32.Parse(str.Split(',').First().Trim());
                            p[i] = Int32.Parse(str.Split(',')[1]);
                            A[i] = Int32.Parse(str.Split(',').Last().Trim());
                        }
                        Priority();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        tat = new float[n];
                        A = new int[n];
                        Console.WriteLine("Enter quantam:");
                        q = Int32.Parse(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time and arrival time seperated by ',' for Process P{0}", i + 1);
                            string getstr = Console.ReadLine();
                            B[i] = Int32.Parse(getstr.Split(',').First());
                            A[i] = Int32.Parse(getstr.Split(',').Last());
                        }
                        RoundRobin();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        //wtt = new int[n];
                        tat = new float[n];
                        A = new int[n];
                        Console.WriteLine("Enter quantum:");
                        q = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time, and arrival time for Process P{0}", i + 1);
                            string str = Console.ReadLine();
                            B[i] = Int32.Parse(str.Split(',').First().Trim());
                            // wtt[i] = Int32.Parse(str.Split(',')[1]);
                            A[i] = Int32.Parse(str.Split(',').Last().Trim());
                        }
                        WeightedRR();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Enter no of processes:");
                        n = Int32.Parse(Console.ReadLine());
                        B = new int[n];
                        tat = new float[n];
                        A = new int[n];

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Enter the burst time and arrival time seperated by ',' for Process P{0}", i + 1);
                            string getstr = Console.ReadLine();
                            B[i] = Int32.Parse(getstr.Split(',').First());
                            A[i] = Int32.Parse(getstr.Split(',').Last());
                        }
                        VariableQuantaRR();
                        break;
                    }


                default:
                    {
                        Console.WriteLine("Choose Option between 1-6");
                        break;
                    }

            }




        }
        public void Fcfs()
        {
            awt = "";
            att = "";
            Twt = 0;
            Wt = new float[n];
            Wt[0] = 0;
            for (int i = 1; i < n; i++)
                Wt[i] = B[i - 1] + Wt[i - 1];

            awt = "";
            att = "";
            //Calculating Average Weighting Time
            for (int i = 0; i < n; i++)
            {
                Wt[i] = Wt[i] - A[i];
                Twt = Wt[i] + B[i];
                tat[i] = Twt - A[i];
                awt = awt + "," + Wt[i].ToString();
                att = att + "," + tat[i].ToString();
            }
            float averageTurnAroundTime = (float)tat.Sum() / n;
            Awt = (float)Wt.Sum() / n;
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("FCFS:Average Turn around Time={0}\nAverage Weighting Time={1}", averageTurnAroundTime, Awt);
            Exit();
        }

        public void Sjf()
        {
            Wt = new float[n];
            //bubble Sort
            int temp;
            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (B[i] > B[i + 1])
                    {
                        temp = B[i + 1];
                        B[i + 1] = B[i];
                        B[i] = temp;
                    }
                }
            }
            Twt = 0;
            Wt[0] = 0;
            for (int i = 1; i < n; i++)
                Wt[i] = B[i - 1] + Wt[i - 1];
            awt = "";
            att = "";
            //Calculating Average Weighting Time
            for (int i = 0; i < n; i++)
            {
                Wt[i] = Wt[i] - A[i];
                Twt = Wt[i] + B[i];
                tat[i] = Twt - A[i];
                awt = awt + "," + Wt[i].ToString();
                att = att + "," + tat[i].ToString();
            }
            float averageTurnAroundTime = (float)tat.Sum() / n;
            Awt = (float)Wt.Sum() / n;
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("Averagee Turn Around Time={0}\nAverage Weighting Time={1}", averageTurnAroundTime, Awt);
            Exit();
        }

        public void Priority()
        {
            int[] pri = new int[n];
            pri = (int[])p.Clone();
            Twt = 0;
            Wt = new float[n];
            int[] wtt = new int[n];
            int[] tt = new int[n];
            int max = pri.Max();
            int maxIndex = pri.ToList().IndexOf(max);
            int temp;
            //Sorting of priority
            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (pri[i] < pri[i + 1])
                    {
                        temp = pri[i + 1];
                        pri[i + 1] = pri[i];
                        pri[i] = temp;
                    }
                }
            }

            Twt = 0;
            Wt[0] = 0;

            awt = "";
            att = "";
            //Calculation of waiting time 
            for (int i = 0; i < n; i++)
            {
                int index = p.ToList().IndexOf(pri[i]);//get index of sorted priority

                if (i > 0)
                {
                    int indexPrev = p.ToList().IndexOf(pri[i - 1]);
                    if ((pri[i] == pri[i - 1]))
                    {
                        index = p.ToList().LastIndexOf(pri[i]);
                    }
                    Wt[i] = B[indexPrev] + Wt[i - 1];//addition of previous waiting time with brust time
                }
                else
                {
                    Wt[i] = 0;
                }
                wtt[index] = (int)Wt[i];
                tt[index] = wtt[index] + B[index];
            }

            //calculating average waiting time
            for (int i = 0; i < n; i++)
            {
                awt = awt + "," + wtt[i].ToString();
                att = att + "," + tt[i].ToString();
            }
            float averageTurnAroundTime = (float)tat.Sum() / n;
            Awt = (float)Twt / n;
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("Average Turn Around Time={0}\nAverage Weighting Time={1}", averageTurnAroundTime, Awt);
            Exit();
        }


        //Completion time t ,turnaround time completionTime-ArrivalTime, weight=turnAroundTime-brustTime
        public void RoundRobin()
        {
            int[] bt = B;
            int[] wt = new int[n];
            int[] rem_bt = new int[n];
           
            int quantum = q;
            {
                for (int i = 0; i < n; i++)
                    rem_bt[i] = bt[i];

                int t = 0;  

                while (true)
                {
                    bool done = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (rem_bt[i] > 0)
                        {
                            done = false;
                            if (rem_bt[i] > quantum && A[i] <= t)
                            {
                                t = t + quantum;
                                rem_bt[i] = rem_bt[i] - quantum;
                            }
                            else
                            {
                                t = t + rem_bt[i];
                                tat[i] = t;
                                wt[i] = t - bt[i];
                                rem_bt[i] = 0;
                            }
                        }
                    }
                    if (done == true)
                        break;
                }
            }
            awt = "";
            att = "";
            for (int i = 0; i < n; i++)
            {
                tat[i] = tat[i] - A[i];
                wt[i] = wt[i] - A[i];

                awt = awt + "," + wt[i].ToString();
                att = att + "," + tat[i].ToString();
            }
            float averageTurnAroundtime = (float)tat.Sum() / n;
            Awt = (float)wt.Sum() / n;
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("Average turn around Time is {0} \n Average weighting time {1}", averageTurnAroundtime, Awt);
            Exit();
        }

        public void WeightedRR()//http://kb.linuxvirtualserver.org/wiki/Weighted_Round-Robin_Scheduling
        {
            int[] bt = B;// new int[10];
            int[] wt = new int[n];
            int[] rem_bt = new int[n];
            string seq = "";
            {
                for (int i = 0; i < n; i++)
                    rem_bt[i] = bt[i];
                int t = 0; // Current time
                while (true)
                {
                    bool done = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (rem_bt[i] > 0)
                        {
                            done = false;
                            while (rem_bt[i] == rem_bt.Max() && rem_bt[i] != 0 && A[i] <= t)
                            {
                                if (rem_bt[i] > q)
                                {
                                    t = t + q;
                                    rem_bt[i] = rem_bt[i] - q;
                                    seq = seq + " ," + "P" + (i + 1).ToString();
                                }
                                else
                                {
                                    t = t + rem_bt[i];
                                    tat[i] = t;
                                    wt[i] = t - bt[i];
                                    rem_bt[i] = 0;
                                    seq = seq + " ," + "P" + (i + 1).ToString();
                                }
                            }
                        }
                    }
                    // If all processes are done 
                    if (done == true)
                        break;
                }
            }
            awt = "";
            att = "";
            for (int i = 0; i < n; i++)
            {
                tat[i] = tat[i] - A[i];
                wt[i] = wt[i] - A[i];
                awt = awt + "," + wt[i].ToString();
                att = att + "," + tat[i].ToString();
            }
            float averageTurnAroundtime = (float)tat.Sum() / n;
            float ave = (float)wt.Sum() / n;
            Console.WriteLine("Process sequence " + seq + "\n");
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("Average turn around Time is {0} \n Average weighting time {1}", averageTurnAroundtime, ave);
            Exit();
        }

        public void VariableQuantaRR()
        {
            int[] bt = B;// new int[10];
            int[] wt = new int[n];
            int[] tt = new int[n];
            int[] rem_bt = new int[n];  
            {
                for (int i = 0; i < n; i++)
                    rem_bt[i] = bt[i];
                int temp = 0;
                for (int j = 0; j <= n - 2; j++)
                {
                    for (int i = 0; i <= n - 2; i++)
                    {
                        if (rem_bt[i] > rem_bt[i + 1])
                        {
                            temp = rem_bt[i + 1];
                            rem_bt[i + 1] = rem_bt[i];
                            rem_bt[i] = temp;
                        }
                    }
                }
                int[] sorted = (int[])rem_bt.Clone();
                int quantum = rem_bt[0];
                int t = 0; // Current time 
                while (true)
                {
                    bool done = true;
                    // Traverse all processes one by one repeatedly 
                    for (int i = 0; i < n; i++)
                    {
                        if (rem_bt[i] > 0)
                        {
                            done = false; // There is a pending process 
                            if (rem_bt[i] > quantum && A[i] <= t)// quantum)
                            {
                                t = t + quantum;
                                rem_bt[i] = rem_bt[i] - quantum;// quantum;
                            }
                            else
                            {
                                t = t + rem_bt[i];
                                tat[i] = t;                                
                                rem_bt[i] = 0;
                            }
                        }
                        if (i == n - 1)
                        {
                            if (rem_bt.Any(m => m > 0))
                            {
                                quantum = rem_bt.Where(m => m != 0).Min();//set quantum to first element of remaining brust time
                            }
                        }
                    }
                    // If all processes are done 
                    if (done == true)
                        break;
                }
                //Calculation of waiting time
                for (int i = 0; i < n; i++)
                {
                    int index = bt.ToList().IndexOf(sorted[i]);
                    if (i > 0)
                    {
                        if ((sorted[i] == sorted[i - 1]))
                        {
                            index = bt.ToList().LastIndexOf(sorted[i]);
                        }
                    }
                    wt[index] = (int)tat[i] - sorted[i];
                    tt[index] = (int)tat[i];
                }
            }
            Twt = 0;
            awt = "";
            att = "";
            for (int i = 0; i < n; i++)
            {
                tat[i] = tt[i] - A[i];
                wt[i] = wt[i] - A[i];
                awt = awt + "," + wt[i].ToString();
                att = att + "," + tat[i].ToString();
            }
            float averageTurnAroundtime = (float)tat.Sum() / n;
            Awt = (float)wt.Sum() / n;
            Console.WriteLine("waiting time are " + awt + "\n Turn around time are " + att);
            Console.WriteLine("average turn around time is {0} \n Average weighting time {1}", averageTurnAroundtime, Awt);
            Exit();
        }

    }
}



