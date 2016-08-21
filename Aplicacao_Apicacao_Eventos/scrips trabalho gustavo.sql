
DROP TABLE IF EXISTS `alunos`;
CREATE TABLE IF NOT EXISTS `alunos` (
  `Cgu` int(11) NOT NULL AUTO_INCREMENT,
  `Nome_Aluno` varchar(45) NOT NULL,
  `Data_nasci` date NOT NULL,
  `Curso` varchar(45) NOT NULL,
  PRIMARY KEY (`cgu`)
) ENGINE=InnoDB AUTO_INCREMENT=111453412 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `eventos` (
  `id_Eventos` int(11) NOT NULL AUTO_INCREMENT,
  `descricao_eventos` varchar(45) NOT NULL,
  `local_eventos` varchar(45) NOT NULL,
  `numero_horas` int(11) NOT NULL,
  `Data_cadastro` date NOT NULL,
  `Data_eventos` date NOT NULL,
  `Cgu` int(11) NOT NULL,
  `id_tipo_evento` int(11) NOT NULL,
  PRIMARY KEY (`id_Eventos`),
  KEY `Cgu` (`Cgu`),
  KEY `id_tipo_evento` (`id_tipo_evento`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `tipos` (
  `id_tipo` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`id_tipo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

CREATE TABLE IF NOT EXISTS `tipo_evento` (
  `id_tipo_evento` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(45) NOT NULL,
  `porcentagem` int(11) NOT NULL,
  `id_tipo` int(11) NOT NULL,
  PRIMARY KEY (`id_tipo_evento`),
  KEY `id_tipo` (`id_tipo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
