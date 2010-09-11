Interaction Homolog Mapping
---------------------------
By Jelmer cnossen

This application takes a set of biobricks from the iGEM part registry (http://partsregistry.org),
and a STRING database ID (http://string-db.org) for every protein-coding biobrick. 
It was made for the iGEM 2010 competition, as part of the TU Delft team. 


It outputs putative interactions in a selected organism (Other than the organism where the genes came from).
For example:
The iGEM 2010 TU Delft team placed 2 proteins (Prefoldin-alpha and beta) from Pyrococcus horikoshii OT3 into E. coli. 
For every Pyrococcus protein that interacts with the Prefoldin according to STRING, homologs where searched for in E. coli.
The homologs in E. coli are candidates for interaction with the prefoldin.


For more detailed explanation and results: 
http://2010.igem.org/Team:TU_Delft#page=Modelling/interaction-mapping

Future goals:
- Use webservices to replace the need for manual input of protein IDs (IAW: use protein sequence blast webservice)
- use a webservice to do homolog mapping, replacing the need to run your own STRING postgresql database.


Coding details:

License: MIT
Language: C#  
Platform: .NET 3.5


For questions, ideas, or patches: mail: j.cnossen( at )gmail.com

