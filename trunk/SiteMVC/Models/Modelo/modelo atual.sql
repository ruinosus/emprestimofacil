SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

CREATE SCHEMA `emprestimo` ;
use `emprestimo`;

CREATE TABLE `area` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `municipio_id` int(10) unsigned NOT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `municipio_id` (`municipio_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `bloqueado` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `motivo` text NOT NULL,
  `cliente_id` int(10) unsigned NOT NULL,
  `usuario_id` int(10) unsigned NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cliente_id` (`cliente_id`),
  KEY `usuario_id` (`usuario_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `cliente` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(150) NOT NULL,
  `rg` varchar(10) DEFAULT NULL,
  `orgaosexpedidoresnome_id` int(10) unsigned DEFAULT NULL,
  `data_expedicao` date DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `ctps` varchar(15) DEFAULT NULL,
  `titulo_eleitor` varchar(15) DEFAULT NULL,
  `zona` varchar(3) DEFAULT NULL,
  `secao` varchar(4) DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  `estadoscivistipo_id` int(10) unsigned DEFAULT NULL,
  `nome_pai` varchar(150) DEFAULT NULL,
  `nome_mae` varchar(150) DEFAULT NULL,
  `endereco_resid` varchar(200) DEFAULT NULL,
  `bairro_resid` varchar(50) DEFAULT NULL,
  `cidade_resid` int(10) unsigned DEFAULT NULL,
  `uf_resid` char(2) DEFAULT NULL,
  `cep_resid` char(8) DEFAULT NULL,
  `fone_resid` char(10) DEFAULT NULL,
  `celular` char(10) DEFAULT NULL,
  `endereco_comerc` varchar(200) DEFAULT NULL,
  `bairro_comerc` varchar(50) DEFAULT NULL,
  `cidade_comerc` int(10) unsigned DEFAULT NULL,
  `uf_comerc` char(2) DEFAULT NULL,
  `cep_comerc` char(8) DEFAULT NULL,
  `fone_comerc` char(10) DEFAULT NULL,
  `nome_ref1` varchar(150) DEFAULT NULL,
  `fone_ref1` char(10) DEFAULT NULL,
  `nome_ref2` varchar(150) DEFAULT NULL,
  `fone_ref2` char(10) DEFAULT NULL,
  `situacao` char(1) DEFAULT NULL,
  `area_id` int(10) unsigned NOT NULL,
  `escolaridade_id` int(10) unsigned DEFAULT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `observacao` VARCHAR(1000) NULL,
  `numcartao` char(16) DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `limite` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `orgaosexpedidoresnome_id` (`orgaosexpedidoresnome_id`),
  KEY `estadoscivistipo_id` (`estadoscivistipo_id`),
  KEY `area_id` (`area_id`),
  KEY `escolaridade_id` (`escolaridade_id`),
  KEY `cidade_resid` (`cidade_resid`),
  KEY `cidade_comerc` (`cidade_comerc`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `despesa` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` date NOT NULL,
  `valor` float NOT NULL,
  `justificativa` varchar(200) DEFAULT NULL,
  `usuario_id` int(10) unsigned NOT NULL,
  `despesatipo_id` int(10) unsigned NOT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `despesatipo_id` (`despesatipo_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `despesatipo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `posdescricao` varchar(50) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `emprestimo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `valor` float NOT NULL,
  `juros` float NOT NULL,
  `qtde_parcelas` int(10) unsigned NOT NULL,
  `data_emprestimo` date NOT NULL,
  `cliente_id` int(10) unsigned NOT NULL,
  `prazospagamento_id` int(10) unsigned NOT NULL,
  `usuario_id` int(10) unsigned NOT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `tipoemprestimo_id` int(10) unsigned DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `cliente_id` (`cliente_id`),
  KEY `prazospagamento_id` (`prazospagamento_id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `tipoemprestimo_id` (`tipoemprestimo_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `escolaridade` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(30) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `estadociviltipo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(20) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `lancamento` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` date NOT NULL,
  `valor` float NOT NULL,
  `usuario_id` int(10) unsigned NOT NULL,
  `lancamentotipo_id` int(10) unsigned NOT NULL,
  `outrasinfos` varchar(100) DEFAULT NULL,
  `observacoes` text,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `fonte` varchar(15) DEFAULT NULL,
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `lancamentotipo_id` (`lancamentotipo_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `lancamentotipo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(40) NOT NULL,
  `sinal` char(1) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `municipio` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `uf` char(2) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `orgaoexpedidornome` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(20) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `parcela` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `sequencial` int(10) unsigned NOT NULL,
  `valor` float NOT NULL,
  `data_vencimento` date NOT NULL,
  `data_pagamento` date DEFAULT NULL,
  `multa_atraso` float DEFAULT NULL,
  `juros_atraso` float DEFAULT NULL,
  `emprestimo_id` int(10) unsigned NOT NULL,
  `statusparcela_id` int(10) unsigned NOT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `visualizada` char(1) NULL,
  `contabilizada` char(1) NULL,
  `valor_pago` float DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `observacoes` text,
  PRIMARY KEY (`id`),
  KEY `emprestimo_id` (`emprestimo_id`),
  KEY `statusparcela_id` (`statusparcela_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `prazopagamento` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `qtde_dias` int(10) unsigned NOT NULL,
  `posdescricao` varchar(10) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE `prestacaoconta` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `dataprestacao` date NOT NULL,
  `totaldespesas` float NOT NULL,
  `valorsaida` float NOT NULL,
  `valoremprestado` float NOT NULL,
  `valorrecebido` float NOT NULL,
  `valordevolvido` float NOT NULL,
  `usuario_id` int(10) unsigned NOT NULL,
  `valorcancelado` float NOT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `parcelareabertas` float DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
    KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `statusparcela` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `tipoemprestimo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `usuario` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(150) NOT NULL,
  `rg` varchar(10) DEFAULT NULL,
  `orgaosexpedidoresnome_id` int(10) unsigned DEFAULT NULL,
  `data_expedicao` date DEFAULT NULL,
  `cpf` varchar(11) DEFAULT NULL,
  `ctps` varchar(15) DEFAULT NULL,
  `titulo_eleitor` varchar(15) DEFAULT NULL,
  `zona` varchar(3) DEFAULT NULL,
  `secao` varchar(4) DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  `estadoscivistipo_id` int(10) unsigned DEFAULT NULL,
  `nome_pai` varchar(150) DEFAULT NULL,
  `nome_mae` varchar(150) DEFAULT NULL,
  `endereco_resid` varchar(200) DEFAULT NULL,
  `bairro_resid` varchar(50) DEFAULT NULL,
  `cidade_resid` varchar(50) DEFAULT NULL,
  `uf_resid` char(2) DEFAULT NULL,
  `cep_resid` char(8) DEFAULT NULL,
  `fone_resid` char(10) DEFAULT NULL,
  `celular` char(10) DEFAULT NULL,
  `login` varchar(16) DEFAULT NULL,
  `senha` varchar(50) DEFAULT NULL,
  `situacao` char(1) DEFAULT NULL,
  `area_id` int(10) unsigned NOT NULL,
  `usuariotipo_id` int(10) unsigned NOT NULL,
  `escolaridade_id` int(10) unsigned DEFAULT NULL,
  `usuariomodificacao_id` INT(10) unsigned DEFAULT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `orgaosexpedidoresnome_id` (`orgaosexpedidoresnome_id`),
  KEY `estadoscivistipo_id` (`estadoscivistipo_id`),
  KEY `area_id` (`area_id`),
  KEY `usuariotipo_id` (`usuariotipo_id`),
  KEY `escolaridade_id` (`escolaridade_id`),
  KEY `usuariomodificacao_id` (`usuariomodificacao_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

CREATE TABLE `usuariotipo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(50) NOT NULL,
  `timeCreated` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `timeUpdated` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;


ALTER TABLE `area`
  ADD CONSTRAINT `area_ibfk_1` FOREIGN KEY (`municipio_id`) REFERENCES `municipio` (`id`),
  ADD CONSTRAINT `area_ibfk_2` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `bloqueado`
  ADD CONSTRAINT `bloqueado_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`),
  ADD CONSTRAINT `bloqueado_ibfk_2` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `cliente`
  ADD CONSTRAINT `cliente_ibfk_1` FOREIGN KEY (`orgaosexpedidoresnome_id`) REFERENCES `orgaoexpedidornome` (`id`),
  ADD CONSTRAINT `cliente_ibfk_2` FOREIGN KEY (`estadoscivistipo_id`) REFERENCES `estadociviltipo` (`id`),
  ADD CONSTRAINT `cliente_ibfk_3` FOREIGN KEY (`area_id`) REFERENCES `area` (`id`),
  ADD CONSTRAINT `cliente_ibfk_4` FOREIGN KEY (`escolaridade_id`) REFERENCES `escolaridade` (`id`),
  ADD CONSTRAINT `cliente_ibfk_5` FOREIGN KEY (`cidade_resid`) REFERENCES `municipio` (`id`),
  ADD CONSTRAINT `cliente_ibfk_6` FOREIGN KEY (`cidade_comerc`) REFERENCES `municipio` (`id`),
  ADD CONSTRAINT `cliente_ibfk_7` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);
  
ALTER TABLE `despesa`
  ADD CONSTRAINT `despesa_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`),
  ADD CONSTRAINT `despesa_ibfk_2` FOREIGN KEY (`despesatipo_id`) REFERENCES `despesatipo` (`id`),
  ADD CONSTRAINT `despesa_ibfk_3` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `emprestimo`
  ADD CONSTRAINT `emprestimo_ibfk_1` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`),
  ADD CONSTRAINT `emprestimo_ibfk_2` FOREIGN KEY (`prazospagamento_id`) REFERENCES `prazopagamento` (`id`),
  ADD CONSTRAINT `emprestimo_ibfk_3` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`),
  ADD CONSTRAINT `emprestimo_ibfk_4` FOREIGN KEY (`tipoemprestimo_id`) REFERENCES `tipoemprestimo` (`id`),
  ADD CONSTRAINT `emprestimo_ibfk_5` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `lancamento`
  ADD CONSTRAINT `lancamento_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`),
  ADD CONSTRAINT `lancamento_ibfk_2` FOREIGN KEY (`lancamentotipo_id`) REFERENCES `lancamentotipo` (`id`),
  ADD CONSTRAINT `lancamento_ibfk_3` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `parcela`
  ADD CONSTRAINT `parcela_ibfk_1` FOREIGN KEY (`emprestimo_id`) REFERENCES `emprestimo` (`id`),
  ADD CONSTRAINT `parcela_ibfk_2` FOREIGN KEY (`statusparcela_id`) REFERENCES `statusparcela` (`id`),
  ADD CONSTRAINT `parcela_ibfk_3` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `prestacaoconta`
  ADD CONSTRAINT `prestacaoconta_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`id`),
  ADD CONSTRAINT `prestacaoconta_ibfk_2` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);

ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`orgaosexpedidoresnome_id`) REFERENCES `orgaoexpedidornome` (`id`),
  ADD CONSTRAINT `usuario_ibfk_2` FOREIGN KEY (`estadoscivistipo_id`) REFERENCES `estadociviltipo` (`id`),
  ADD CONSTRAINT `usuario_ibfk_3` FOREIGN KEY (`area_id`) REFERENCES `area` (`id`),
  ADD CONSTRAINT `usuario_ibfk_4` FOREIGN KEY (`usuariotipo_id`) REFERENCES `usuariotipo` (`id`),
  ADD CONSTRAINT `usuario_ibfk_5` FOREIGN KEY (`escolaridade_id`) REFERENCES `escolaridade` (`id`),
  ADD CONSTRAINT `usuario_ibfk_6` FOREIGN KEY (`usuariomodificacao_id`) REFERENCES `usuario` (`id`);
