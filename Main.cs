using System;
using System.Text; 
using System.IO; 
using System.Collections.Generic;
class Reservation
{
    //List of the 4 possible journeys 
    static List<string> lesLiaisons = new List<string>
    {
        "Lorient --> Groix",
        "Groix --> Lorient",
        "Quiberon --> Belle-île",
        "Belle-île --> Quiberon"
    };

    static Dictionary<string,string> Pass_Categories = new Dictionary<string,string>
    {
        {"adu26p" , "Adulte 26 ans et plus "},
        {"jeu1825" , "Jeune 18 à 25 ans inclus"},
        {"enf417","Enfant 4 à 17 ans inclus"},
        {"bebe","Bébé moins de 4 ans "},
        {"ancomp","Animal de compagnie"},
        

    };

    static Dictionary<string, string> Vehicule_Categories = new Dictionary<string, string>
    {
        { "trot", "Trottinette électrique" },
        { "velo", "Vélo ou remorque à vélo" },
        { "velelec", "Vélo électrique" },
        { "cartand", "Vélo cargo ou tandem" },
        { "mobil", "Deux-roues <= 125 cm3" },
        { "moto", "Deux-roues > 125 cm3" },
        { "cat1", "Voiture moins de 4 m" },
        { "cat2", "Voiture de 4 m à 4.39 m" },
        { "cat3", "Voiture de 4.40 m à 4.79 m" },
        { "cat4", "Voiture 4.80 m et plus" },
        { "camp", "Camping-car - véhicule plus de 2.10 de haut" }
    };


    struct Traversee
    {
        public short liaison;
        public short date; 
        public short depart;
    }

    //structure des passagers 
    struct Passagers 
    {
        public string Nom;
        public string Prenom; 
        public short Code; 


        public Passagers(string nom , string prenom , short code)
        {
            Nom = nom; 
            Prenom = prenom; 
            Code = code; 
        }
        
    } 

    //structure des vehicules
    struct Vehicules
    {
        public string Code; 
        public short Quantite;

        public Vehicules(string code , short quantite)
        {
            Code = code; 
            Quantite = quantite; 
        } 
    } 




    static void Main()
    {
        //HEADER 
        Console.WriteLine("====================================");
        Console.WriteLine("  SYSTEME DE RESERVATION - LA CAN  ");
        Console.WriteLine("         Novembre 2025              ");
        Console.WriteLine("====================================");
        Console.WriteLine();


        //NOM DE RESERVATION
        Console.WriteLine("Nom de la reservation :");
        Console.Write("> ");
        string nom_reser = Console.ReadLine(); 


        //CHOIX DE LA LIAISON
        
        bool corr_liaison = false; 
        Console.WriteLine();
        Console.WriteLine("Choisissez une liaison :");
        Console.WriteLine("1 - Lorient -> Groix");
        Console.WriteLine("2 - Groix -> Lorient");
        Console.WriteLine("3 - Quiberon -> Le Palais");
        Console.WriteLine("4 - Le Palais -> Quiberon");
        short choix_ligne = 0; 
        while(!corr_liaison)
        {

            Console.Write("> ");
            choix_ligne = short.Parse(Console.ReadLine()); 

            if(choix_ligne < 1 || choix_ligne > 4 )
            {
                Console.WriteLine("CHOISIR UN NOMBRE ENTRE 1 ET 4 !!!!");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("c'est bon vous avez choisis la ligne n°" + choix_ligne + " correspont à " +  lesLiaisons[choix_ligne-1]);
                corr_liaison = true; 
            }

        }

        //CHOIX DU JOUR EXACT
        bool corr_jour = false;
        short choix_jour = 0; 
            Console.WriteLine();
            Console.WriteLine("Choisissez un jour de depart (01 a 30) :");

        while (!corr_jour)    
        {
            Console.Write("> ");
            choix_jour = short.Parse(Console.ReadLine()); 
            if(choix_jour < 1 || choix_jour > 30)
            {
                Console.WriteLine("CHOISIR UN JOUR ENTRE 1 ET 30 NOVEMBRE !!!!");
            }
            else 
            {
                Console.WriteLine();
                Console.WriteLine("C'est bon vous avez choisis le " + choix_jour + " Novembre.");
                corr_jour = true; 
            }
        }


        //INSERER LES PASSAGERS
        
        Console.WriteLine();
        Console.WriteLine("=== SAISIE DES PASSAGERS ===");
        Console.WriteLine("Combien de passagers ?");
        Console.Write("> ");
        short nbr_passagers = short.Parse(Console.ReadLine()); 

        List<Passagers> L_passagers = new List<Passagers>(); 

        //BOUCLE SUR LE NOMBRE DU PASSAGERS 
            for (int i = 0 ; i < nbr_passagers ; i++)
            {


                Console.WriteLine();
                Console.WriteLine("Nom du '" + (i+1) + "' :");
                Console.Write("> ");
                string nom_passagers = Console.ReadLine(); 

                Console.WriteLine("Prenom du passager '" + (i+1) + "' :");
                Console.Write("> ");
                string prenom_passagers = Console.ReadLine(); 

                Console.WriteLine("Categorie du passager '" + (i+1) + "' :");
                Console.WriteLine(" 1- adu26p  (Adulte)");
                Console.WriteLine(" 2- jeu1825 (Jeune)");
                Console.WriteLine(" 3- enf417  (Enfant)");
                Console.WriteLine(" 4- bebe    (Bebe)");
                Console.WriteLine(" 5- ancomp  (Animal)");
                Console.Write("> ");
                short pass_categorie = short.Parse(Console.ReadLine());

                Passagers p = new Passagers(nom_passagers , prenom_passagers , pass_categorie);

                L_passagers.Add(p); 


            }
            //INSERTION DES VEHICULES 
            Console.WriteLine();
            Console.WriteLine("=== SAISIE DES VEHICULES ===");
            Console.WriteLine("Souhaitez-vous ajouter un vehicule ? (oui / non)");
            Console.Write("> ");
            string ve_confirmation = Console.ReadLine();
            short nbr_vehicules = 0;  
            List<Vehicules> L_Vehicules = new List<Vehicules>();   

            if(ve_confirmation == "oui" || ve_confirmation == "OUI" || ve_confirmation == "o" || ve_confirmation == "O")
            {
                Console.WriteLine("combien de vehicules svp : ");
                Console.Write("> ");
                nbr_vehicules = short.Parse(Console.ReadLine()); 


                for(int v = 0 ; v < nbr_vehicules ; v++)
                {


                    Console.WriteLine("Categorie du vehicule :");
                    Console.Write("> ");
                    string ve_categorie = Console.ReadLine();  //reference Code in vehicule structure

                    Console.WriteLine("Quantite :");
                    Console.Write("> ");
                    short ve_quantity  = short.Parse(Console.ReadLine());  //reference Quantite in Vehicules structure 

                    Vehicules vehicule = new Vehicules(ve_categorie , ve_quantity);
                    L_Vehicules.Add(vehicule); 


                }
                
            } 

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("        RECAPITULATIF                ");
            Console.WriteLine("====================================");
            Console.WriteLine("Nom de reservation choisis : " + nom_reser);
            Console.WriteLine("Liaison choisis : " +  lesLiaisons[choix_ligne - 1]) ;
            Console.WriteLine("Jour choisis : "  + choix_jour);
            Console.WriteLine("Nombre des passagers : " + nbr_passagers);
            for(int a = 0 ; a < L_passagers.Count ; a++)
            {
                
                Console.WriteLine("Passager N°" + a+1 + " : ");
                Console.WriteLine(L_passagers[a].Nom);
                Console.WriteLine(L_passagers[a].Prenom);
                Console.WriteLine(L_passagers[a].Code); 
                Console.WriteLine("----------------------------"); 
            }
            
            Console.WriteLine("Nombre des vehicules : " + nbr_vehicules);
            
            for(int k = 0 ; k < L_Vehicules.Count ; k++)
            {
                
                Console.WriteLine("Vehicule N°" + k+1 + " : ");
                Console.WriteLine(L_Vehicules[k].Code);
                Console.WriteLine(L_Vehicules[k].Quantite);
                Console.WriteLine("----------------------------"); 
                
            }
        }
    }









