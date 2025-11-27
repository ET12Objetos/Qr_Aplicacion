<h1 align="center">E.T. Nº12 D.E. 1º "Libertador Gral. José de San Martín"</h1>
<p align="center">
  <img src="https://et12.edu.ar/imgs/et12.svg" width="140">
</p>

# 🧾 Sistema de Boletería – Gestión de Eventos y Entradas con QR

Proyecto desarrollado para la materia **Proyecto Informático II**, implementando un sistema completo de administración de eventos, venta de entradas y validación mediante códigos QR.  
La solución incluye backend en C#, acceso a datos con Dapper, procedimientos SQL, validación de QR y una arquitectura por capas orientada al mantenimiento y escalabilidad.

---

## 📌 Asignaturas involucradas
- Base de Datos  
- Laboratorio de Programación Orientada a Objetos  
- Proyecto Informático II  
- Análisis de Sistemas  

---

## 👨‍💻 Integrantes del grupo
- **Martinez Roa, Alina Fiorella**
- **Paetz, Rodolfo**
- **Alconz, Maycol**

**Curso:** 5° 7ma  
**Año Lectivo:** 2025

---

# 🚀 Tecnologías utilizadas

| Área | Tecnología |
|------|------------|
| Backend | C# (.NET 9.0) |
| ORM | Dapper + ADO.NET |
| Base de Datos | MySQL 8 |
| Testing | xUnit 2.4 |
| Arquitectura | API + Core + Repository + Services |
| Documentación | Draw.io + Markdown |

---

# 📁 Estructura del proyecto

```txt
Qr_Aplicacion-main/
│
├── docs/
│ ├── DER.md
│ ├── CasosdeUso.drawio.svg
│ └── diaagrama.drawio
│
├── scripts/
│ └── bd/MySQL
│ ├── DDL.sql
│ ├── INSERTS.sql
│ ├── PROCEDURE.sql
│ ├── TRIGGERS.sql
│ └── USER.sql
│
├── src/
│ └── cSharp/
│ ├── SistemaDeBoleteria.API/
│ ├── SistemaDeBoleteria.Core/
│ ├── SistemaDeBoleteria.Repository/
│ ├── SistemaDeBoleteria.Services/
│ └── SistemaDeBoleteria.Tests/
│
└── README.md
```

---

# 🗄️ Base de datos

Todos los scripts están en:
```txt
/scripts/bd/MySQL/
```

Scripts incluidos:

1. **DDL.sql** – Creación de tablas  
2. **INSERTS.sql** – Datos iniciales  
3. **PROCEDURE.sql** – Procedimientos almacenados  
4. **TRIGGERS.sql** – Lógica automática de BD  
5. **USER.sql** – Gestión de roles de MySQL  

---

# ⚙️ Instalación

## 1. Clonar el repositorio

```bash


git clone https://github.com/star-lightt/Qr_Aplicacion

```
#  Configurar la base de datos MySQL

## Ejecutar en orden:

```txt
1. DDL.sql
2. INSERTS.sql
3. TRIGGERS.sql
4. PROCEDURE.sql
5. USER.sql (opcional)
```

# Configurar cadena de conexión

## Editar dentro de:
```txt
src/cSharp/SistemaDeBoleteria.API/appsettings.json
```

```txt
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=5to_SistemaDeBoleteria;User=root;Password=1234;"
  }
}
```

# Restaurar dependencias
```bash
cd src/cSharp/SistemaDeBoleteria.API
dotnet restore
```
#  Ejecutar la API
```bash
dotnet run
```
