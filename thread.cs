// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Threading;
using System.Collections.Generic;
public class HelloWorld
{
    public static int count=0;
    private static readonly object lockObject = new object(); 
    public static void Summation(int k){
         
        for(int i=0;i<k*1000;i++){
//lock so that only one thread could have access to change the value of count
            lock(lockObject){
            count+=i;
            }
            // Console.WriteLine (count);
        }
    }
    public static void Main(string[] args)
    {
        List<Thread> list=new List<Thread>();
        for(int i=0;i<5;i++){
            int localI=i;
            Thread x=new Thread(()=> Summation(localI));
            list.Add(x);
// start the thread 
            x.Start();
            
            
        }
        for(int i=0;i<list.Count;i++){
// it will let the main thread to wait for completion of each thread that have been started
            list[i].Join();
        }
  

        Console.WriteLine(count);
        Console.WriteLine ("Try programiz.pro");
    }
    
}
