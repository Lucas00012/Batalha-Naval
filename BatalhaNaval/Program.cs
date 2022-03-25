using BatalhaNaval.Core.Entities;

Console.WriteLine(@"
.______        ___   .___________.    ___       __       __    __       ___      
|   _  \      /   \  |           |   /   \     |  |     |  |  |  |     /   \     
|  |_)  |    /  ^  \ `---|  |----`  /  ^  \    |  |     |  |__|  |    /  ^  \    
|   _  <    /  /_\  \    |  |      /  /_\  \   |  |     |   __   |   /  /_\  \   
|  |_)  |  /  _____  \   |  |     /  _____  \  |  `----.|  |  |  |  /  _____  \  
|______/  /__/     \__\  |__|    /__/     \__\ |_______||__|  |__| /__/     \__\ 
                                                                                 
.__   __.      ___   ____    ____  ___       __                                  
|  \ |  |     /   \  \   \  /   / /   \     |  |                                 
|   \|  |    /  ^  \  \   \/   / /  ^  \    |  |                                 
|  . `  |   /  /_\  \  \      / /  /_\  \   |  |                                 
|  |\   |  /  _____  \  \    / /  _____  \  |  `----.                            
|__| \__| /__/     \__\  \__/ /__/     \__\ |_______|                                                     
");

Console.WriteLine(@"
Sejam bem vindos AO MELHOR JOGO DO UNIVERSO!
Ganhamos o título 'Game of the year (GOTY) em 2022, 2021, 2020, 2019, ... 1957'

Objetivo: Afundar todos os navios do adversário
Jogadores: 2 jogadores

Como jogar?
    - O jogo irá começar com cada um dos participantes inserindo seus navios no tabuleiro;
    - Ao inserir seus navios no tabuleiro, peça para seu amiguinho fechar os olhos (não nos responsabilizamos);
    - Tanto para inserir navios quanto para atacar o adversário, é necessário especificar as coordenadas do tabuleiro;
    - Ao especificar uma coordenada, deve ser respeitado o formato (linha,coluna) sem os parênteses.
");
Console.WriteLine("Pressione qualquer tecla para começar...");
Console.ReadKey();
Console.Clear();

var partida = new Partida();
partida.Jogar();

Console.ReadKey();
