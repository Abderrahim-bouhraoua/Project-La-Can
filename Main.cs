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

    static string[] Pass_Categories = { "adu26p", "jeu1825", "enf417", "bebe", "ancomp" };

    static List<string> Vehicule_Categories = new List<string> 
    { 

        "trot", "velo", "velelec" ,"cartand",
        "mobil", "moto", 
        "cat1", "cat2", "cat3", "cat4",
        "camp" 
    };

    // ===== TARIFS PASSAGERS =====

    // GROIX
    static Dictionary<string, double> Tarifs_Passagers_Groix = new Dictionary<string, double>()
    {
        { "adu26p", 18.75 },
        { "jeu1825", 13.80 },
        { "enf417", 11.25 },
        { "bebe", 0.0 },
        { "ancomp", 3.35 }
    };

    // BELLE-ILE
    static Dictionary<string, double> Tarifs_Passagers_BelleIle = new Dictionary<string, double>()
    {
        { "adu26p", 18.80 },
        { "jeu1825", 14.10 },
        { "enf417", 11.65 },
        { "bebe", 0.0 },
        { "ancomp", 3.35 }
    };


    // ===== TARIFS VEHICULES =====

    // GROIX
    static Dictionary<string, double> Tarifs_Vehicules_Groix = new Dictionary<string, double>()
    {
        { "trot", 4.70 },
        { "velo", 8.20 },
        { "velelec", 11.00 },
        { "cartand", 16.45 },
        { "mobil", 23.10 },
        { "moto", 66.05 },
        { "cat1", 96.05 },
        { "cat2", 114.80 },
        { "cat3", 174.45 },
        { "cat4", 210.90 },
        { "camp", 330.20 }
    };

    // BELLE-ILE
    static Dictionary<string, double> Tarifs_Vehicules_BelleIle = new Dictionary<string, double>()
    {
        { "trot", 4.70 },
        { "velo", 8.20 },
        { "velelec", 11.00 },
        { "cartand", 16.45 },
        { "mobil", 23.35 },
        { "moto", 66.40 },
        { "cat1", 98.50 },
        { "cat2", 117.20 },
        { "cat3", 176.90 },
        { "cat4", 213.35 },
        { "camp", 332.70 }
    };



    struct Traversee
    {
        public short liaison;
        public string date; 
        public string depart;
    }

    //structure des passagers 
    struct Passagers 
    {
        public string Nom;
        public string Prenom; 
        public string Code; 


        public Passagers(string nom , string prenom , string code)
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
        Console.WriteLine("Choisissez une liaison (1 a 4):");
        Console.WriteLine("1 - Lorient -> Groix");
        Console.WriteLine("2 - Groix -> Lorient");
        Console.WriteLine("3 - Quiberon -> Le Palais");
        Console.WriteLine("4 - Le Palais -> Quiberon");
        short choix_ligne = 0; 
    
        while(!corr_liaison)
        {
            try 
            {

                Console.Write("> ");
                choix_ligne = short.Parse(Console.ReadLine()); 

                if(choix_ligne < 1 || choix_ligne > 4 )
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR !!!! CHOISIR UN NOMBRE ENTRE 1 ET 4 !!!!");
                    Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine();
                    Console.WriteLine("c'est bon vous avez choisis la ligne N°" + choix_ligne + " correspont à " +  lesLiaisons[choix_ligne-1]);
                    corr_liaison = true; 
                }
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                Console.WriteLine();
            }

        }

        //CHOIX DU JOUR EXACT
        bool corr_jour = false;
        short choix_jour = 0; 
            Console.WriteLine();
            Console.WriteLine("Choisissez un jour de depart (01 a 30) :");

        while (!corr_jour)    //BOUCLE POUR LE CORRECT INPUT
        {
            try 
            {

                Console.Write("> ");
                choix_jour = short.Parse(Console.ReadLine().Trim());
                if(choix_jour < 1 || choix_jour > 30)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR !!!! CHOISIR UN JOUR ENTRE LE 1 ET 30 NOVEMBRE MERCI.");
                    Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine();
                    Console.WriteLine("C'est bon vous avez choisis le " + choix_jour + " Novembre.");
                    corr_jour = true; 
                }
            }
            catch 
            {
                Console.WriteLine();
                Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                Console.WriteLine();
            }
        }


        //LECTURE DU FICHIER CSV DES HORAIRES
        //DIC POUR STOCKER LES HORAIRES
        Dictionary<short, Dictionary<short , List<string>>> D_horaires = new Dictionary<short, Dictionary<short , List<string>>>();

        //LECRETURE DE CHAQUE LIGNES DANS LE CSV ET AFFICHAGE DU BON HORAIRES
        string[] lines = File.ReadAllLines("horaires.csv");

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(';');

            short jour = short.Parse(parts[0]);
            short liaisonId = short.Parse(parts[1]);
            string[] heures = parts[2].Split('-');

            if (!D_horaires.ContainsKey(jour))
                D_horaires[jour] = new Dictionary<short, List<string>>();

            if (!D_horaires[jour].ContainsKey(liaisonId))
                D_horaires[jour][liaisonId] = new List<string>();

            D_horaires[jour][liaisonId].AddRange(heures);
        }

        Console.WriteLine();
        Console.WriteLine("Les horaires disponible dans le " + choix_jour + " Novembre pour la liaison (" + lesLiaisons[choix_ligne-1] + ").");
        Console.WriteLine();
        short iteration = 1; 
        foreach(string h in D_horaires[choix_jour][choix_ligne])
        {

            Console.WriteLine(iteration + "- " + h);
            iteration++; 
        }

        //CHOIX D'HORAIRES
        Console.WriteLine();
        Console.WriteLine("Choisissez l'horaire qui vous convient (de 1 à " + (iteration-1) + ").");
        short heure = 0;
        bool corr_heure = false;
        while(!corr_heure)
        {
            try 
            {
                
                Console.Write("> ");
                heure = short.Parse(Console.ReadLine());
                if (heure <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR !!!! LE NOMBRE QUE VOUS AVEZ CHOISIS EST NEGATIVE.");
                    Console.WriteLine();
                }
                else if(heure > iteration - 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR !!!! CHOISIS UN NOMBRE ENTE (1 ET " + (iteration-1) + ")");
                    Console.WriteLine();
                }
                else 
                {
                    corr_heure = true; 
                }
            }
            catch 
            {
                Console.WriteLine();
                Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                Console.WriteLine();
            }
        }
        string choix_heure = D_horaires[choix_jour][choix_ligne][heure-1];
        Console.WriteLine();
        Console.WriteLine("c'est bon vous avez choisis : " + choix_heure);

        //REMPLIR LA STRUCTURE TRAVERSEE 
        Traversee t;
        t.liaison = choix_ligne;
        t.date = "2025-11-" + choix_jour.ToString("00");
        t.depart = choix_heure;



        //INSERER LES PASSAGERS
        
        Console.WriteLine();
        Console.WriteLine("=== SAISIE DES PASSAGERS ===");
        Console.WriteLine("Combien de passagers ?");
        bool corr_num_pass = false; 
        short nbr_passagers = 0;
        while (!corr_num_pass)
        {
            try
            {
                Console.Write("> ");
                nbr_passagers = short.Parse(Console.ReadLine());

                if(nbr_passagers <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR: Le nombre doit être supérieur à 0!");
                    Console.WriteLine();
                }
                else
                {
                    corr_num_pass = true; 
                }
            }
            catch 
            {
                Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
            }

        }
        List<Passagers> L_passagers = new List<Passagers>(); 

        //BOUCLE SUR LE NOMBRE DU PASSAGERS 
            for (int i = 0 ; i < nbr_passagers ; i++)
            {

                Console.WriteLine();
                Console.WriteLine("Nom du passager (" + (i+1) + "):");
                Console.Write("> ");
                string nom_passagers = Console.ReadLine(); 

                Console.WriteLine("Prenom du passager (" + (i+1) + ") :");
                Console.Write("> ");
                string prenom_passagers = Console.ReadLine(); 

                short cat_num = 0; 
                bool corr_cate = false;
                Console.WriteLine("Choisissez la Categorie du passager  (" + (i+1) + ") ENTRE 1 ET 5:");
                Console.WriteLine();
                Console.WriteLine(" 1- adu26p  (Adulte 26 ans et plus )");
                Console.WriteLine(" 2- jeu1825 (Jeune 18 à 25 ans inclus)");
                Console.WriteLine(" 3- enf417  (Enfant 4 à 17 ans inclus)");
                Console.WriteLine(" 4- bebe    (Bébé moins de 4 ans )");
                Console.WriteLine(" 5- ancomp  (Animal de compagnie)");

                while(!corr_cate)
                {
                    try 
                    {
                        Console.WriteLine();
                        Console.Write("> ");
                        cat_num = short.Parse(Console.ReadLine());
                        if(cat_num < 1 || cat_num > 5)
                        {
                            Console.WriteLine();
                            Console.Write("ERREUR !!!! CHOISIR UN NOMBRE DE (1 à 5) MERCI.");
                            Console.WriteLine();

                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("C'est bon vous avez choisis la categorie " + Pass_Categories[cat_num-1]);
                            corr_cate = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                        Console.WriteLine();
                    }
                }

                string pass_categorie = Pass_Categories[cat_num -1]; //Liste static avec le code de chaque categorie  
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
        bool corr_ve_nbr = false ; 
        
        if(ve_confirmation == "oui" || ve_confirmation == "OUI" || ve_confirmation == "o" || ve_confirmation == "O" || ve_confirmation == "oui " || ve_confirmation == "o " )
        {
            Console.WriteLine("combien de vehicules svp : ");

            while(!corr_ve_nbr)
            {
                Console.Write("> ");
                try 
                {

                    nbr_vehicules = short.Parse(Console.ReadLine()); 
                    if (nbr_vehicules <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERREUR !!!! NOMBRE NEGATIF OU VOUS AVEZ CHOISIS 0 (Merci de saisir le bon nombre.) ");
                        Console.WriteLine();
                    }
                    else if(nbr_vehicules > 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Malheureusement on peut pas acceuillir plus que 10 vehicules. Merci.");
                        Console.WriteLine();
                    }
                    else 
                    {
                        Console.WriteLine();
                        Console.WriteLine("C'est bon vous avez choisis " + nbr_vehicules + " vehicules.");
                        corr_ve_nbr = true; 
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                    Console.WriteLine();
                }
            }

            for(int v = 0 ; v < nbr_vehicules ; v++)
            {
                Console.WriteLine();
                Console.WriteLine("Type de vehicule (" + (v+1) + ") :");
                Console.WriteLine("1- Vélo / trottinette");
                Console.WriteLine("2- Deux-roues motorisé");
                Console.WriteLine("3- Voiture");
                Console.WriteLine("4- Camping-car / véhicule special");
                string ve_categorie = null; //reference Code in vehicule structure
                bool corr_ve_cat = false; 
                bool corr_ve_cat1 = false; 
                bool corr_ve_cat2 = false; 
                bool corr_ve_cat3 = false; 
                while(!corr_ve_cat)
                {
                    ConsoleKeyInfo user_in = Console.ReadKey();
                    switch(user_in.KeyChar)
                    {
                        case '1':
                        case '&':

                            Console.WriteLine();
                            Console.WriteLine("Categorie vélo / trottinette :");
                            Console.WriteLine("1- Trottinette électrique");
                            Console.WriteLine("2- Vélo ou remorque à vélo");
                            Console.WriteLine("3- Vélo électrique");
                            Console.WriteLine("4- Vélo cargo ou tandem");
                            while(!corr_ve_cat1)
                            {
                                ConsoleKeyInfo user_in_cat1 = Console.ReadKey();
                                switch(user_in_cat1.KeyChar)
                                {
                                    case '&':
                                    case '1':
                                        ve_categorie = Vehicule_Categories[0];  
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[0]);
                                        Console.WriteLine();
                                        corr_ve_cat1 = true; 
                                        break;           
                                    case '2':
                                    case 'é':
                                        ve_categorie = Vehicule_Categories[1]; 
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[1]);
                                        Console.WriteLine();
                                        corr_ve_cat1 = true; 
                                        break;
                                    case '3':
                                    case '"':
                                        ve_categorie = Vehicule_Categories[2];
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[2]);
                                        Console.WriteLine();
                                        corr_ve_cat1 = true; 
                                        break;
                                    case '4':
                                    case '\'':
                                        ve_categorie = Vehicule_Categories[3];
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[3]);
                                        Console.WriteLine();
                                        corr_ve_cat1 = true; 
                                        break;
                                    default:
                                        Console.WriteLine("\nChoix invalide"); 
                                        break;
                                }
                            }

                        corr_ve_cat = true; 
                        break;

                        case '2':
                        case 'é':
                            Console.WriteLine();
                            Console.WriteLine("Categorie deux-roues motorisé :");
                            Console.WriteLine("1- Deux-roues <= 125 cm3");
                            Console.WriteLine("2- Deux-roues > 125 cm3");
                            while(!corr_ve_cat2)
                            {
                                ConsoleKeyInfo user_in_cat2 = Console.ReadKey();
                                switch(user_in_cat2.KeyChar)
                                {
                                    case '1':
                                    case '&':
                                        ve_categorie = Vehicule_Categories[4];   
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[4]);
                                        Console.WriteLine();
                                        corr_ve_cat2 = true; 
                                        break;           
                                    case '2':
                                    case 'é':
                                        ve_categorie = Vehicule_Categories[5];
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[5]);
                                        Console.WriteLine();
                                        corr_ve_cat2 = true; 
                                        break;
                                    default:
                                        Console.WriteLine("\nChoix invalide"); 
                                        break;
                                }                            
                            }

                        corr_ve_cat = true; 
                        break;

                        case '3':
                        case '"':
                            Console.WriteLine("Categorie voiture :");
                            Console.WriteLine();
                            Console.WriteLine("1- Voiture moins de 4 m");
                            Console.WriteLine("2- Voiture de 4 m à 4.39 m");
                            Console.WriteLine("3- Voiture de 4.40 m à 4.79 m");
                            Console.WriteLine("4- Voiture 4.80 m et plus");
                            while(!corr_ve_cat3)
                            {
                                ConsoleKeyInfo user_in_cat3 = Console.ReadKey();
                                switch(user_in_cat3.KeyChar)
                                {
                                    case '1':
                                    case '&':
                                        ve_categorie = Vehicule_Categories[6];  
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[6]);
                                        Console.WriteLine();
                                        corr_ve_cat3 = true; 
                                        break;           
                                    case '2':
                                    case 'é':
                                        ve_categorie = Vehicule_Categories[7]; 
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[7]);
                                        Console.WriteLine();
                                        corr_ve_cat3 = true; 
                                        break;
                                    case '3':
                                    case '"':
                                        ve_categorie = Vehicule_Categories[8];
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[8]);
                                        Console.WriteLine();
                                        corr_ve_cat3 = true; 
                                        break;
                                    case '4':
                                    case '\'':
                                        ve_categorie = Vehicule_Categories[9];
                                        Console.WriteLine();
                                        Console.WriteLine("Categorie sélectionnée : " + Vehicule_Categories[9]);
                                        Console.WriteLine();
                                        corr_ve_cat3 = true; 
                                        break;
                                    default:
                                        Console.WriteLine("\nChoix invalide"); 
                                        break;
                                }
                            }

                        corr_ve_cat = true; 
                        break;

                        case '4':
                        case '\'':
                            Console.WriteLine();
                            Console.WriteLine("Categorie sélectionnée : Camping-car / véhicule special");
                            ve_categorie = Vehicule_Categories[10];
                            corr_ve_cat = true; 
                            break;

                        default:
                            Console.WriteLine("\nChoix invalide"); 
                            break;
                    }
                }

                Console.WriteLine("Quantite :");
                short ve_quantity  = 0;  //reference Quantite in Vehicules structure 
                bool corr_quant = false; 
                while(!corr_quant)
                {
                    Console.Write("> ");
                    try 
                    {
                        ve_quantity  = short.Parse(Console.ReadLine());  //reference Quantite in Vehicules structure 
                        if(ve_quantity < 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERREUR !!!! CHOISIS UN NOMBRE POSITIF MERCI.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("C'est bon vous avez choisis " + ve_quantity + " vehicules du type " + ve_categorie);
                            Console.WriteLine();
                            corr_quant = true; 
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERREUR: Veuillez entrer un nombre valide!");
                        Console.WriteLine();
                    }
                }

                    Vehicules vehicule = new Vehicules(ve_categorie , ve_quantity);
                    L_Vehicules.Add(vehicule);
                }
            }

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("        RECAPITULATIF                ");
            Console.WriteLine("====================================");
            Console.WriteLine("Nom de reservation choisis : " + nom_reser);
            Console.WriteLine();
            Console.WriteLine("Liaison choisis : " +  lesLiaisons[choix_ligne - 1]) ;
            Console.WriteLine();
            Console.WriteLine("Jour choisis : "  + choix_jour);
            Console.WriteLine();
            Console.WriteLine("Nombre des passagers : " + nbr_passagers);
            Console.WriteLine();

            for(int a = 0 ; a < L_passagers.Count ; a++)
            {
                
                Console.WriteLine("Passager N°" + (a+1) + " : ");
                Console.WriteLine(L_passagers[a].Nom);
                Console.WriteLine(L_passagers[a].Prenom);
                Console.WriteLine(L_passagers[a].Code); 
                Console.WriteLine("----------------------------"); 
            }
            
            Console.WriteLine();
            Console.WriteLine("Nombre des vehicules : " + nbr_vehicules);
            Console.WriteLine();
            
            for(int k = 0 ; k < L_Vehicules.Count ; k++)
            {
                
                Console.WriteLine("Vehicule N°" + (k+1) + " : ");
                Console.WriteLine(L_Vehicules[k].Code);
                Console.WriteLine(L_Vehicules[k].Quantite);
                Console.WriteLine("----------------------------"); 
                
            }

            // ===== CHOIX DESTINATION =====
            bool si_Groix = false;

            if(choix_ligne == 1 || choix_ligne == 2)
            {
                si_Groix = true;
            }

            // ===== SELECTION DES TARIFS =====
            Dictionary<string, double> Tarifs_Passagers;
            Dictionary<string, double> Tarifs_Vehicules;

            if(si_Groix)
            {
                Tarifs_Passagers = Tarifs_Passagers_Groix;
                Tarifs_Vehicules = Tarifs_Vehicules_Groix;
            }
            else
            {
                Tarifs_Passagers = Tarifs_Passagers_BelleIle;
                Tarifs_Vehicules = Tarifs_Vehicules_BelleIle;
            }

            // ===== CALCUL PRIX PASSAGERS =====
            double prix_passagers = 0;

            for(int i = 0 ; i < L_passagers.Count ; i++)
            {
                prix_passagers += Tarifs_Passagers[L_passagers[i].Code];
            }

            // ===== CALCUL PRIX VEHICULES =====
            double prix_vehicules = 0;

            for(int i = 0 ; i < L_Vehicules.Count ; i++)
            {
                prix_vehicules += Tarifs_Vehicules[L_Vehicules[i].Code] * L_Vehicules[i].Quantite;
            }

            // ===== TOTAL =====
            double prix_total = prix_passagers + prix_vehicules;

            Console.WriteLine();
            Console.WriteLine("=== PRIX A PAYER ===");
            Console.WriteLine("Passagers : " + prix_passagers + " €");
            Console.WriteLine("Vehicules : " + prix_vehicules + " €");
            Console.WriteLine("TOTAL : " + prix_total + " €");

            // ===== CREATION DU FICHIER JSON =====

            StringBuilder json = new StringBuilder();

            // tableau de reservations
            json.Append("[\n");
            json.Append("  {\n");

            // reservation
            json.Append("    \"reservation\": {\n");
            json.Append("      \"nom\": \"" + nom_reser + "\",\n");
            json.Append("      \"idLiaison\": " + choix_ligne + ",\n");
            json.Append("      \"date\": \"2025-11-" + choix_jour.ToString("00") + "\",\n");
            json.Append("      \"heure\": \"" + choix_heure + "\",\n");
            json.Append("      \"horodatage\": \"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\"\n");
            json.Append("    },\n");

            // passagers
            json.Append("    \"passagers\": [\n");
            for(int i = 0 ; i < L_passagers.Count ; i++)
            {
                json.Append("      {\n");
                json.Append("        \"nom\": \"" + L_passagers[i].Nom + "\",\n");
                json.Append("        \"prenom\": \"" + L_passagers[i].Prenom + "\",\n");
                json.Append("        \"codeCategorie\": \"" + L_passagers[i].Code + "\"\n");
                json.Append("      }");

                if(i < L_passagers.Count - 1)
                    json.Append(",\n");
                else
                    json.Append("\n");
            }
            json.Append("    ],\n");

            // vehicules
            json.Append("    \"vehicules\": [\n");
            for(int i = 0 ; i < L_Vehicules.Count ; i++)
            {
                json.Append("      {\n");
                json.Append("        \"codeCategorie\": \"" + L_Vehicules[i].Code + "\",\n");
                json.Append("        \"quantite\": " + L_Vehicules[i].Quantite + "\n");
                json.Append("      }");

                if(i < L_Vehicules.Count - 1)
                    json.Append(",\n");
                else
                    json.Append("\n");
            }
            json.Append("    ]\n");

            // fermeture
            json.Append("  }\n");
            json.Append("]\n");

            // ecriture fichier
            File.WriteAllText("reservation.json", json.ToString());

            Console.WriteLine();
            Console.WriteLine("Fichier reservation.json cree avec succes");


        }
}
