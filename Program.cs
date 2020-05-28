using System;

namespace ALGO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsOneEdit("xxxbcfd","xxzbcdf"));

            //Console.WriteLine(IsPalindrom("aabbcccde"));

            //Console.WriteLine(CompressString("GGGGGdddddKJKJTTTTTiiiiOIOIyyyyyyRRRRRccccc"));

            //Console.WriteLine(MaxStockPrice(new int[]{5,4,3,2,1}));
        }

        //Array problems
        //Commit on master 1
        public static bool IsOneEdit(string s1,string s2){
            int l1 = s1.Length;
            int l2 = s2.Length;

            if(l1>l2&&l2+1!=l1)return false;
            else if(l1<l2&&l1+1!=l2)return false;

            int ptr1 = 0;
            int ptr2 = 0;
            bool isOneEditFound = false;

            while(ptr1<l1&&ptr2<l2){
                if(s1[ptr1]==s2[ptr2]){
                    ptr1++;ptr2++;
                }
                else if(!isOneEditFound){
                    isOneEditFound = true;
                    if(l1>l2){
                        ptr1++;
                    }
                    else if(l1<l2){
                        ptr2++;
                    }
                    else{
                        ptr1++;ptr2++;
                    }
                }
                else{
                    return false;
                }
            }
            if(l1!=l2 && !isOneEditFound){
                isOneEditFound = true;
            }
            return isOneEditFound;
        }

        public static bool IsPalindrom(string str){
            char[] letters = new char[str.Length];
            int[] counts = new int[str.Length];

            int currentCounter = -1;
            foreach(var c in str){
                currentCounter = InsertIntoTable(letters,counts,c,currentCounter);
            }

            bool firstOddEncounter = false;
            bool isPalindrom = true; 

            for(int i = 0; i<=currentCounter;i++){
                if(counts[i]%2!=0 && !firstOddEncounter){
                    firstOddEncounter = true;
                }else if(firstOddEncounter){
                    isPalindrom = false;
                }
            }

            return isPalindrom;
        }

        public static int InsertIntoTable(char[] letters,int[] counts,char c,int current){

            bool charFound = false;
            if(current == -1){
                letters[0] = c;
                counts[0] = 1;
                return 0;
            }
            for(int i = 0;i<=current;i++){
                if(letters[i]==c){
                    charFound = true;
                    counts[i]++;
                    return current;
                }
            }

            if(!charFound){
                letters[current+1] = c;
                counts[current+1] = 1;
                return current+1;
            }

            return -1;
        }

        public static string CompressString(string str){
            if(str=="")return str;
            int ptr = 1;
            string compressedStr = "";
            char prev = str[0];
            char current = str[0];

            int count = 1;

            while(ptr<str.Length){
                current = str[ptr];

                if(current==prev){
                    count++;
                }
                else{
                    compressedStr = compressedStr + prev + count;
                    count = 1;
                }
                prev = current;
                ptr++;
                if(compressedStr.Length>str.Length)return str;
            }
            compressedStr = compressedStr + prev + count;
            if(compressedStr.Length>str.Length)return str;
            return compressedStr;
        }
    
        public static int MaxStockPrice(int[] arr){

             int min = 0;
             int current = 1;

             int maxProfit = 0;
             bool increasing =  false;

             while(current<arr.Length){
                 if(arr[current]>arr[current-1]){
                     increasing = true;
                 }else {
                     if(increasing){
                        maxProfit = maxProfit + arr[current-1]-arr[min];
                        increasing = false;
                     }
                     min = current;
                 }
                 current++;
             }
             if(arr[current-1]>arr[min]){
                 maxProfit = maxProfit + arr[current-1]-arr[min];
             }
             return maxProfit;
        }
    }
}
