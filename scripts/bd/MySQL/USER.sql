DROP USER IF EXISTS 'usuario'@'localhost';
DROP USER IF EXISTS 'organizador'@'localhost';
DROP USER IF EXISTS 'administrador'@'localhost';
DROP USER IF EXISTS 'controlacceso'@'localhost';

CREATE USER 'usuario'@'localhost' IDENTIFIED BY 'User123!';

GRANT INSERT ON AuthTokens TO 'usuario'@'localhost';
GRANT SELECT, INSERT, UPDATE ON 5to_SistemaDeBoleteria.Usuario TO 'usuario'@'localhost';
GRANT SELECT ON 5to_SistemaDeBoleteria.Evento TO 'usuario'@'localhost';
GRANT SELECT ON 5to_SistemaDeBoleteria.Funcion TO 'usuario'@'localhost';
GRANT SELECT ON 5to_SistemaDeBoleteria.Tarifa TO 'usuario'@'localhost';

GRANT INSERT, UPDATE ON 5to_SistemaDeBoleteria.Orden TO 'usuario'@'localhost';
GRANT INSERT, UPDATE ON 5to_SistemaDeBoleteria.Entrada TO 'usuario'@'localhost';
GRANT INSERT, SELECT ON 5to_SistemaDeBoleteria.QR TO 'usuario'@'localhost';


GRANT INSERT ON AuthTokens TO 'organizador'@'localhost';
CREATE USER 'organizador'@'localhost' IDENTIFIED BY 'Org123!';

GRANT SELECT, INSERT, UPDATE, DELETE ON 5to_SistemaDeBoleteria.Evento TO 'organizador'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON 5to_SistemaDeBoleteria.Funcion TO 'organizador'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON 5to_SistemaDeBoleteria.Tarifa TO 'organizador'@'localhost';

GRANT SELECT ON 5to_SistemaDeBoleteria.Orden TO 'organizador'@'localhost';
GRANT SELECT ON 5to_SistemaDeBoleteria.Entrada TO 'organizador'@'localhost';
GRANT SELECT ON 5to_SistemaDeBoleteria.QR TO 'organizador'@'localhost';

CREATE USER 'administrador'@'localhost' IDENTIFIED BY 'Admin123!';

GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.authtokens TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.cliente TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.entrada TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.funcion TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.evento TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.local TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.orden TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.qr TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.sector TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.tarifa TO 'administrador'@'localhost';
GRANT SELECT, INSERT, DELETE, UPDATE  ON 5to_SistemaDeBoleteria.usuario TO 'administrador'@'localhost';


GRANT INSERT ON AuthTokens TO 'controlacceso'@'localhost';
CREATE USER 'controlacceso'@'localhost' IDENTIFIED BY 'Acceso123!';

GRANT SELECT, UPDATE ON 5to_SistemaDeBoleteria.Entrada TO 'controlacceso'@'localhost';
GRANT SELECT, UPDATE ON 5to_SistemaDeBoleteria.QR TO 'controlacceso'@'localhost';

FLUSH PRIVILEGES;
