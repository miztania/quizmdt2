namespace array{
     
    
    class Program {
        static void Main(string[] args){
                Console.WriteLine("Enter number of spaces: ");
                int amounts = int.Parse(Console.ReadLine());

                string[] area = new string[amounts] ;

                for(int i = 0 ; i<amounts ; i++){
                    area[i] = "_";
                }

                while(true){
                   
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = int.Parse(Console.ReadLine());
                   

                    if((input1 == 0 || input2 == 0) || (input1 < 0 || input2 < 0)){
                        if(isSpaceFree(area,CheckNumValid(input1,input2)-1)){
                              area[CheckNumValid(input1,input2) - 1] = "X";
                              ShowArea(area);
                        }else{
                              Console.WriteLine("The stall is reserved.");  
                        }
                      

                    }else if((input1 == 0 && input2 == 0) || (input1 < 0 && input2 < 0)){
                         Console.WriteLine("End");
                         break;
                    }else if(input1 == input2){

                        if(isSpaceFree(area,CheckNumValid(input1,input2)-1)){
                              area[CheckNumValid(input1,input2) - 1] = "X";
                              ShowArea(area);
                        }else{
                              Console.WriteLine("The stall is reserved.");  
                        }

                    }else{
                            if(isSpaceFree(area,input1-1) && isSpaceFree(area,input2-1)){
                                if( numReserved(area) + 2 == amounts ){
                                    Console.WriteLine("The entrance can’t be reserved."); 
                                }else{
                                    area[input1-1] = "X";
                                    area[input2-1] = "X";
                                    ShowArea(area);
                                }
                          
                            }else{
                                 Console.WriteLine("The stall is reserved.");  
                            }
                              
                        
                    }

                    if (CheckIfAllReserved(area,amounts)){
                          Console.WriteLine("All stall are reserved.");
                         break;
                    }


                }
        }

        static int CheckNumValid(int num1,int num2){
                if(num1  > 0 && num1 != 0){
                    return num1;
                }else if (num2  > 0 && num2 != 0){
                    return num2;
                }else{
                    return 0;
                }
        }

        static void ShowArea(string[] area){
                for(int i = 0 ; i< area.Length ; i++){
                    Console.Write(area[i]);
                }
                   Console.WriteLine("");
        }

        static private bool CheckIfAllReserved(string[] area ,int amounts)
        {
            int xCount = 0;
            foreach( string i in area){
                if(i == "X"){
                    xCount++;
                }
            }

            if(xCount+1 == amounts){
                return true;
            }else{
                return false;
            }
        }

        static private bool isSpaceFree(string[] area,int num){
            return (area[num] != "X");
        }

        static private int numReserved(string[] area){
            int xCount = 0;
            foreach( string i in area){
                if(i == "X"){
                    xCount++;
                }
            }
            return xCount;
        }

     

    }
}
