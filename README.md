# NOMBRE: Proyecto final IAV26

**Autores**
- [María Eduarda Beckers](https://github.com/MaEduardaB)
- [Haoshuang Hou](https://github.com/HaoshuangHou)
- [Bingcheng Wang](https://github.com/bingoo30)
---
## Índice

1. [Resumen](#1-resumen)  
2. [Instalación y uso](#2-instalación-y-uso)  
   2.1. [Ejecutable](#21-ejecutable)  
   2.2. [Vídeo](#22-vídeo)  
3. [Planteamiento del problema](#3-planteamiento-del-problema)  
   3.A. [Entorno](#3a-entorno)  
   3.B. [Enunciado B](#3b-enunciado-b)  
   3.C. [Enunciado C](#3c-enunciado-c)  
   3.D. [Enunciado D](#3d-enunciado-d)  
   3.E. [Enunciado E](#3e-enunciado-e)  
4. [Diseño de la solución](#4-diseño-de-la-solucion)  
   4.1. [Controles](#41-controles)  
   4.2. [HUD](#42-hud)  
   4.3. [Comportamientos implementados](#43-comportamientos-implementados)  
5. [Implementación](#5-implementación)  
6. [Pruebas y métricas](#6-pruebas-y-métricas)  
7. [Conclusión](#7-conclusión)  
8. [Evolución y distribución](#8-evolución-y-distribución)  
9. [Licencias](#9-licencia)  
10. [Referencias](#10-referencias)
---
## 1. Resumen 

Este proyecto es un proyecto final práctica de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos de la UCM.

Se trata de un prototipo básico basado en nuestro juego de Zapascape de la asignatura Proyectos 3.

El objetivo es conseguir la mejor puntuación recogiendo zapatos teniendo en cuanta su peso y su valor, intentando maximizar la puntuación. Cuanto más peso lleves, más lento caminarás.

## 2. Instalación y uso

Todo el contenido del proyecto está disponible en este repositorio, utilizamos Unity 6 **(versión).**

### 2.1 Ejecutable
En el repositorio se localiza el ejecutable de dicha práctica para poder experimentar los comportamientos: [TAG DE EJECUTABLE]()

### 2.2 Vídeo
- [IAV26-G07-P1](https://youtu.be/aDzJ2DPpiCw) — Vídeo documental con las pruebas del juego (oculto en YouTube)

## 3. Planteamiento del problema
Tenemos un escenario de Unity 3D que está compuesto por ...

El prototipo permitirá:
### 3.A. Entorno
    
### 3.B. Enunciado B
    
### 3.C. Enunciado C

### 3.D. Enunciado D
implementacion
### 3.E. Enunciado E
metrica
En cuanto a interfaz...

## 4. Diseño de la solución

El proyecto contará con 3 escenas:
- Escena inicial: el menú de inicio de la simulación que tendrá un botón para iniciar la simulación.
- Escena principal: simulación del juego.
- Escena final: indicará que bot ha conseguido la mejor puntuación y botones para salir o reiniciar la simulación.


### 4.1. Controles

|Input|Función|
|--|--|
|**O**|crear una rata|

### 4.2. HUD
![Interfaz](DocImages/interfaz.png)
| Elemento | Tipo | Funcionalidad |
|----------|------|--------------|
| Cam. fija | Botón | Coloca la cámara en una posición y rotación predeterminadas. |
| Pantalla dividida | Botón | La pantalla se dividirá en dos, cambiando de la cámara principal a las cámaras de los dos bots |
| Puntuaciones | Texto | Indirá la puntuacción actual de los dos bots |
| Salir | Botón | Cerrar el programa |
| Reiniciar | Botón | Reiniciar la simulación |
| Temporizador | Texto | Un cuenta atrás que indicará cuanto tiempo queda para finalizar la simulación |

### 4.3. Comportamientos implementados

#### Beastie rojo
   Utilizará machine learning para aprender que acciones le resultaran una mayor puntuación. Al realizar la simulación una serie de veces, el Beastie rojo deberá ser capaz de rocojer zapatos y devolverlos a su base, llevando en cuenta el tiempo que ha tardado en devolver el zapato y su valor.

**Algo**
- Descripcion.
- Características:
	1. x
- Pseudocódigo:
``` csharp
class Hola
```
#### Beastie morado
   Utilizará GOAP para la recogida de zapatos.

#### Tux 
   Es el personaje que estará molestando a los dos beasties de conseguir los zapatos. Usará árbol de comportamiento para estar disparando proyectiles hacia los beasties. Tux estará caminando desde fuera de la mapa a una altura superior usando la navMesh de Unity, cuando llegue a una esquina, su nuevo objetivo será la siguiente esquina. A cada cierto tiempo disparará un proyectil teniendo en cuenta la distancia y la puntuación de cada beastie, haciendo una ponderación entre esos dos parámetros.


## 5. Implementación
**A.**
**B.**
**C.**
**D.**
**E.**


## 6. Pruebas y métricas

A continuación se detalla un plan de pruebas para verificar que se cumplen todos los requisitos del enunciado. Se organiza por apartados (A–E) según las características.

**Apartado A.**
1. Hacer algo:
   - Confirmar que algo funcione de tal forma.

**Apartado B.**
**Apartado C.**
**Apartado D.**
**Apartado E.**



## 7. Conclusión



## 8. Evolución y distribución

## 9. Licencia
- Uso educativo y de investigación – Universidad Complutense de Madrid
- Copyright (c) 2026 María Eduarda Beckers, Haoshuang Hou, Bingcheng Wang
- Se concede permiso permanente a los profesores de la Facultad de Informática de la Universidad Complutense de Madrid para utilizar, reproducir, modificar o distribuir total o parcialmente este material (código) con fines exclusivamente educativos o de investigación.
- Se permite el uso de datos derivados de forma agregada y anónima, así como la inclusión del material en trabajos académicos, siempre con reconocimiento expreso de los autores.
- Esta licencia no otorga derechos de uso comercial ni de explotación fuera del ámbito académico o de investigación, salvo autorización expresa de los autores.
- Arte, música y recursos audiovisuales: todos los assets han sido creados por los autores del proyecto y se distribuyen exclusivamente bajo las mismas condiciones de uso educativo y de investigación descritas anteriormente, quedando prohibido su uso comercial sin autorización expresa.

## 10. Referencias
