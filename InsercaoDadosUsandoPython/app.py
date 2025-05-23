from pymongo import MongoClient
from datetime import datetime

###########################################################################################################################

# Conexão com o MongoDB local
client = MongoClient("mongodb://localhost:27017")
db = client["ODONTOPREV"]


# Documento de paciente
PACIENTES = [
    {
        "nm_paciente": "Beto Mal Hálito",
        "nr_cpf": "09317440088",
        "dt_nascimento": datetime.strptime("1990-02-06", "%Y-%m-%d"),
        "ds_sexo": "M",
        "ds_email": "beto.halito@gmail.com",
        "nr_telefone": "27965563215",

        "PLANO": {
            "ds_codigo_plano": "ODP001",
            "nm_plano": "Básico"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do siso",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-01-02", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Cáries nos dentes superiores",
                    "dt_analise_raio_x": datetime.strptime("2024-01-05", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
            "nm_dentista": "Dr. Otto Canino",
            "ds_cro": "CRO312544"
            }
        ]  

    },
    {
        "nm_paciente": "Branca Dente",
        "nr_cpf": "00780976061",
        "dt_nascimento": datetime.strptime("1987-10-31", "%Y-%m-%d"),
        "ds_sexo": "F",
        "ds_email": "branca.dente@gmail.com",
        "nr_telefone": "11975853524",

        "PLANO": {
            "ds_codigo_plano": "ODP002",
            "nm_plano": "Intermediário"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do molar",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-02-05", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Infecção no dente molar",
                    "dt_analise_raio_x": datetime.strptime("2024-02-10", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [
            {
                "dt_extrato": datetime.strptime("2022-05-25", "%Y-%m-%d"),
                "ds_movimentacao": "Respondeu a pergunta",
                "nr_numero_pontos": 100
            },
            {
                "dt_extrato": datetime.strptime("2019-12-13", "%Y-%m-%d"),
                "ds_movimentacao": "Resgatou nr_numero_pontos",
                "nr_numero_pontos": 150
            },
            {
                "dt_extrato": datetime.strptime("2024-05-05", "%Y-%m-%d"),
                "ds_movimentacao": "Respondeu a pergunta",
                "nr_numero_pontos": 200
            },
            {
                "dt_extrato": datetime.strptime("2024-02-03", "%Y-%m-%d"),
                "ds_movimentacao": "Enviou Raio X",
                "nr_numero_pontos": 250
            },
            {
                "dt_extrato": datetime.strptime("2022-07-09", "%Y-%m-%d"),
                "ds_movimentacao": "Fez uma limpeza",
                "nr_numero_pontos": 300
            },
            {
                "dt_extrato": datetime.strptime("2021-04-28", "%Y-%m-%d"),
                "ds_movimentacao": "Fez uma avaliação",
                "nr_numero_pontos": 350
            },
            {
                "dt_extrato": datetime.strptime("2023-07-07", "%Y-%m-%d"),
                "ds_movimentacao": "Resgatou nr_numero_pontos",
                "nr_numero_pontos": 400
            },
            {
                "dt_extrato": datetime.strptime("2023-11-19", "%Y-%m-%d"),
                "ds_movimentacao": "Respondeu a pergunta",
                "nr_numero_pontos": 450
            },
            {
                "dt_extrato": datetime.strptime("2022-06-27", "%Y-%m-%d"),
                "ds_movimentacao": "Fez uma limpeza",
                "nr_numero_pontos": 500
            },
            {
                "dt_extrato": datetime.strptime("2020-07-22", "%Y-%m-%d"),
                "ds_movimentacao": "Enviou Raio X",
                "nr_numero_pontos": 550
            }
        ],

        "DENTISTA": [
            {
                "nm_dentista": "Dr. Ben Dente",
                "ds_cro": "CR245565"
            }
        ]
    },
    {
        "nm_paciente": "Geni giva",
        "nr_cpf": "39600754055",
        "dt_nascimento": datetime.strptime("1995-01-18", "%Y-%m-%d"),
        "ds_sexo": "F",
        "ds_email": "geni.giva@gmail.com",
        "nr_telefone": "31963254785",

        "PLANO": {
            "ds_codigo_plano": "ODP003",
            "nm_plano": "Premium"
        },

        "CHECK_IN": [
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você é fumante?",
                "resposta": "Sim"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você já visitou um dentista esse ano?",
                "resposta": "Não"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você sente dor ao mastigar?",
                "resposta": "Sim"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você já fez limpeza dentária esse ano?",
                "resposta": "Sim"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você já escovou os dentes hoje?",
                "resposta": "Não"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você tem algum problema de gengiva?",
                "resposta": "Sim"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você já fez tratamento de canal?",
                "resposta": "Não"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você usa fio dental regularmente?",
                "resposta": "Sim"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você já extraiu algum dente?",
                "resposta": "Não"
            },
            {
                "data": datetime.strptime("2024-02-02", "%Y-%m-%d"),
                "pergunta": "Você masca chicletes com frequência?",
                "resposta": "Sim"
            }
        ],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do pré-molar",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-03-08", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Abscesso no pré-molar",
                    "dt_analise_raio_x": datetime.strptime("2024-03-15", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dr. Álvaro Canal",
                "ds_cro": "CR52865"
            }
        ]
    },
    {
        "nm_paciente": "João Tártaro",
        "nr_cpf": "12724268075",
        "dt_nascimento": datetime.strptime("06/02/1992", "%d/%m/%Y"),
        "ds_sexo": "M",
        "ds_email": "joao.tartaro@gmail.com",
        "nr_telefone": "35932100586",

        "PLANO": {
            "ds_codigo_plano": "ODP004",
            "nm_plano": "Empresarial"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do canino",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-04-11", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Perda óssea devido à periodontite",
                    "dt_analise_raio_x": datetime.strptime("2024-04-20", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dra. Marina Molar",
                "ds_cro": "CR986422"
            }
        ]
    },
    {
         "nm_paciente": "Carie Alves",
        "nr_cpf": "44797031018",
        "dt_nascimento": datetime.strptime("25/11/1983", "%d/%m/%Y"),
        "ds_sexo": "N",
        "ds_email": "carie.alves@gmail.com",
        "nr_telefone": "45932014563",

        "PLANO": {
            "ds_codigo_plano": "ODP005",
            "nm_plano": "Familiar"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x panorâmico",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-05-15", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Dente impactado no siso inferior",
                    "dt_analise_raio_x": datetime.strptime("2024-05-25", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dr. Ali Vramento",
                "ds_cro": "CR098964"
            }
        ]
    },
    {
        "nm_paciente": "Sara Dente",
        "nr_cpf": "23953879081",
        "dt_nascimento": datetime.strptime("20/08/1991", "%d/%m/%Y"),
        "ds_sexo": "N",
        "ds_email": "sara.dente@gmail.com",
        "nr_telefone": "54946852335",

        "PLANO": {
            "ds_codigo_plano": "ODP006",
            "nm_plano": "Executivo"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x da mandíbula",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-06-19", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Lesão óssea na mandíbula",
                    "dt_analise_raio_x": datetime.strptime("2024-06-30", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dra. Aparecida do Sorriso",
                "ds_cro": "CRO99001"
            }
        ]
    },
    {
        "nm_paciente": "Ligia Dor",
        "nr_cpf": "35423149002",
        "dt_nascimento": datetime.strptime("30/06/1988", "%d/%m/%Y"),
        "ds_sexo": "F",
        "ds_email": "ligia.dor@gmail.com",
        "nr_telefone": "11985652545",

        "PLANO": {
            "ds_codigo_plano": "ODP007",
            "nm_plano": "Estudante"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do maxilar",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-07-23", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Fratura dentária no incisivo",
                    "dt_analise_raio_x": datetime.strptime("2024-07-05", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dra. Isa Carie",
                "ds_cro": "CR856934"
            }
        ]
    },
    {
        "nm_paciente": "Ryan Quebrado",
        "nr_cpf": "67641380018",
        "dt_nascimento": datetime.strptime("01/09/1990", "%d/%m/%Y"),
        "ds_sexo": "N",
        "ds_email": "ryan.quebrado@gmail.com",
        "nr_telefone": "25975254562",

        "PLANO": {
            "ds_codigo_plano": "ODP008",
            "nm_plano": "Infantil"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do incisivo",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-08-28", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Dente supranumerário detectado no maxilar superior",
                    "dt_analise_raio_x": datetime.strptime("2024-08-10", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dra. Clara Mente",
                "ds_cro": "CR125863"
            }
        ]
    },
    {
        "nm_paciente": "Ronaldo Banguela",
        "nr_cpf": "93430420008",
        "dt_nascimento": datetime.strptime("22/03/1994", "%d/%m/%Y"),
        "ds_sexo": "M",
        "ds_email": "ronaldo.banguela@gmail.com",
        "nr_telefone": "11998547565",

        "PLANO": {
            "ds_codigo_plano": "ODP005",
            "nm_plano": "Familiar"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do canino",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-09-02", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Cisto dentário em formação ao redor do canino",
                    "dt_analise_raio_x": datetime.strptime("2024-09-15", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dr. Cláudio Gengiva",
                "ds_cro": "CRO88990"
            }
        ]
    },
    {
        "nm_paciente": "Josefina Quebra Queixo",
        "nr_cpf": "91952855047",
        "dt_nascimento": datetime.strptime("09/03/1985", "%d/%m/%Y"),
        "ds_sexo": "F",
        "ds_email": "josefina.quebra.queixo@gmail.com",
        "nr_telefone": "32963254777",

        "PLANO": {
            "ds_codigo_plano": "ODP010",
            "nm_plano": "Master"
        },

        "CHECK_IN": [],

        "RAIO_X": [
            {
                "ds_raio_x": "Raio_x do molar",
                "im_raio_x": None,
                "dt_data_raio_x": datetime.strptime("2024-10-06", "%Y-%m-%d"),
                "analise": {
                    "ds_analise_raio_x": "Cárie radicular no molar inferior direito",
                    "dt_analise_raio_x": datetime.strptime("2024-10-20", "%Y-%m-%d")
                }
            }
        ],

        "EXTRATO_PONTOS": [],

        "DENTISTA": [
            {
                "nm_dentista": "Dra. Sonia Brilho",
                "ds_cro": "CR203587"
            }
        ]
    }
]

# Documento de dentista
DENTISTAS = [
    {
        "nm_dentista": "Dr. Otto Canino",
        "ds_cro": "CRO312544",
        "ds_email": "otto.canino@gmail.com",
        "nr_telefone": "31932158752",
        "ds_doc_identificacao": "12579320000127"
    },
    {
        "nm_dentista": "Dr. Ben Dente",
        "ds_cro": "CR245565",
        "ds_email": "ben.dente@gmail.com",
        "nr_telefone": "62901985212",
        "ds_doc_identificacao": "16874896000178"
    },
    {
        "nm_dentista": "Dr. Álvaro Canal",
        "ds_cro": "CR52865",
        "ds_email": "alvaro.canal@gmail.com",
        "nr_telefone": "11999855776",
        "ds_doc_identificacao": "59225989000184"
    },
    {
        "nm_dentista": "Dra. Marina Molar",
        "ds_cro": "CR986422",
        "ds_email": "marina.molar@gmail.com",
        "nr_telefone": "11933255774",
        "ds_doc_identificacao": "93908189000104"
    },
    {
        "nm_dentista": "Dr. Ali Vramento",
        "ds_cro": "CR098964",
        "ds_email": "ali.vramento@gmail.com",
        "nr_telefone": "45988552211",
        "ds_doc_identificacao": "75234663000170"
    },
    {
        "nm_dentista": "Dra. Aparecida do Sorriso",
        "ds_cro": "CRO99001",
        "ds_email": "aparecida.sorriso@gmail.com",
        "nr_telefone": "84966665786",
        "ds_doc_identificacao": "42526327000141"
    },
    {
        "nm_dentista": "Dra. Isa Carie",
        "ds_cro": "CR856934",
        "ds_email": "isa.carie@gmail.com",
        "nr_telefone": "11955863320",
        "ds_doc_identificacao": "07316233000147"
    },
    {
        "nm_dentista": "Dra. Clara Mente",
        "ds_cro": "CR125863",
        "ds_email": "clara.mente@gmail.com",
        "nr_telefone": "3394563325",
        "ds_doc_identificacao": "36816900000159"
    },
    {
        "nm_dentista": "Dr. Cláudio Gengiva",
        "ds_cro": "CRO88990",
        "ds_email": "claudio.gengiva@gmail.com",
        "nr_telefone": "2733755886",
        "ds_doc_identificacao": "46805824000130"
    },
    {
        "nm_dentista": "Dra. Sonia Brilho",
        "ds_cro": "CR203587",
        "ds_email": "sonia.brilho@gmail.com",
        "nr_telefone": "63977523258",
        "ds_doc_identificacao": "50241419000103"
    }
]

# Limpar as coleções antes de inserir os novos dados
db.PACIENTES.delete_many({})
db.DENTISTAS.delete_many({})

# Inserção no MongoDB
db.PACIENTES.insert_many(PACIENTES)
db.DENTISTAS.insert_many(DENTISTAS)

# Exibir mensagem de sucesso
print("Dados inserido com sucesso!")

