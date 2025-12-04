using System;
using System.Text; 
using System.IO; 
using System.Collections.Generic;
class Reservation
{
    //List of the 4 possible journeys 
    List<string> lesLiaisons = new List<string>
    {
        "Lorient --> Groix",
        "Groix --> Lorient",
        "Quiberon --> Belle-île",
        "Belle-île --> Quiberon"
    };

    //List for similar hours for days in the month for the first journey 

    //    -Lorient --> Groix
    //and there is one left i will add directly in the dictionary
    List<string> J_LG_1 = new List<string>{9:45 - 12:15 - 17:00, 19:30};
    List<string> J_LG_2 = new List<string>{8:05 - 11:00 - 13:45 - 16:15 - 18:45};

    //    -Groix --> Lorient
    //one left i will add directly in the dictionary
    List<string> J_GL_1 = new List<string>{8:30 - 11:00 - 15:45 - 18:15};
    List<string> J_GL_2 = new List<string>{6:50 - 9:30 - 12:30 - 15:00 - 17:30};

    //    -Quiberon --> Belle-île
    //there is 9 distinct ones left i will add directly into the dictionary
    List<string> J_QB_1 = new List<string>{08:00, 09:30, 11:15, 14:15, 17:30, 19:30};
    List<string> J_QB_2 = new List<string>{08:15, 11:15, 14:15, 16:15, 17:30, 19:30};
    List<string> J_QB_3 = new List<string>{08:00, 09:30, 11:15, 14:15, 16:15, 17:15, 20:00};
    List<string> J_QB_4 = new List<string>{08:00, 09:30, 11:15, 14:15, 17:15, 19:15, 20:15};

    //     -Belle-île --> Quiberon
    //there is 9 distinct ones left that i will add directly into the dictionary
    List<string> J_BQ_1 = new List<string>{06:30, 07:45, 09:45, 12:45, 15:45, 18:00};
    List<string> J_BQ_2 = new List<string>{07:00, 09:45, 12:45, 14:45, 15:45, 18:00}; 
    List<string> J_BQ_3 = new List<string>{06:30, 07:45, 09:45, 12:45, 14:45, 15:45, 18:30};
    List<string> J_BQ_4 = new List<string>{06:30, 07:45, 09:45, 12:45, 15:45, 17:45, 18:45};



    //Dictionary of the first journey LG 
    Dictionary<string, List<string>> Horaires_LG = new Dictionary<string,List<string>>
    {
        "01",J_LG_1
        "02",J_LG_1
        "03",J_LG_2
        "04",J_LG_2
        "05",J_LG_2
        "06",J_LG_2
        "07",J_LG_2
        "08",J_LG_2
        "09",J_LG_1
        "10",J_LG_2
        "11",J_LG_1
        "12",J_LG_2
        "13",new List<string>{8:05 - 11:00 - 13:45 - 18:45};
        "14",J_LG_2
        "15",J_LG_2
        "16",J_LG_1
        "17",J_LG_2
        "18",J_LG_2
        "19",J_LG_2
        "20",J_LG_2
        "21",J_LG_2
        "22",J_LG_2
        "23",J_LG_1
        "24",J_LG_2
        "25",J_LG_2
        "26",J_LG_2
        "27",J_LG_2
        "28",J_LG_2
        "29",J_LG_2
        "30",J_LG_1
    };

    Dictionary<string, List<string>> Horaires_LG = new Dictionary<string,List<string>>
    {
        "01",J_LG_1
        "02",J_LG_1
        "03",J_LG_2
        "04",J_LG_2
        "05",J_LG_2
        "06",J_LG_2
        "07",J_LG_2
        "08",J_LG_2
        "09",J_LG_1
        "10",J_LG_2
        "11",J_LG_1
        "12",J_LG_2
        "13",new List<string>{8:05 - 11:00 - 13:45 - 18:45};
        "14",J_LG_2
        "15",J_LG_2
        "16",J_LG_1
        "17",J_LG_2
        "18",J_LG_2
        "19",J_LG_2
        "20",J_LG_2
        "21",J_LG_2
        "22",J_LG_2
        "23",J_LG_1
        "24",J_LG_2
        "25",J_LG_2
        "26",J_LG_2
        "27",J_LG_2
        "28",J_LG_2
        "29",J_LG_2
        "30",J_LG_1
    };
    
}