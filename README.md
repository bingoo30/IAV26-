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
   3.B. [Movimiento del personaje](#3b-movimiento-del-personaje)  
   3.C. [NPC](#3c-npc)  
   3.D. [Bots](#3d-bots)  
   3.E. [Métricas](#3e-métricas)  
4. [Diseño de la solución](#4-diseño-de-la-solucion)  
   4.1. [Controles](#41-controles)  
   4.2. [HUD](#42-hud)  
   4.3. [Comportamientos implementados](#43-comportamientos-implementados)  
   4.3.1 [Beastie Rojo](#beastie-rojo)  
   4.3.2 [Beastie Morado](#beastie-morado)   
   4.3.2 [Tux](#tux)

5. [Implementación](#5-implementación)  
6. [Pruebas y métricas](#6-pruebas-y-métricas)  
7. [Conclusión](#7-conclusión)  
8. [Evolución y distribución](#8-evolución-y-distribución)  
9. [Licencias](#9-licencia)  
10. [Referencias](#10-referencias)
---
## 1. Resumen 

Para el proyecto final de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos de la UCM, se desarrolla un prototipo básico basado en Zapascape, nuestro juego de la asignatura Proyectos 3.

El objetivo consiste en conseguir la mejor puntuación posible recogiendo zapatos, teniendo en cuenta su peso y su valor, con el fin de maximizar la puntuación final. Esta propuesta está inspirada en el típico problema de la mochila.

## 2. Instalación y uso

Todo el contenido del proyecto está disponible en este repositorio, utilizamos Unity 6 **(6000.3.12f1).**

### 2.1 Ejecutable
En el repositorio se localiza el ejecutable de dicha práctica para poder experimentar los comportamientos: [TAG DE EJECUTABLE]()

### 2.2 Vídeo
- [IAV26-ProyectoFinal](ENLACE) — Vídeo documental con las pruebas del juego (oculto en YouTube)

## 3. Planteamiento del problema
El proyecto consiste en desarrollar un escenario en Unity 3D compuesto por dos personajes jugables, varios objetos recolectables, la base de cada jugador y un NPC que encargado de dificultar las acciones de los avatares. 
El objetivo del jugador es maximizar la puntuación obtenida, teniendo en cuenta el valor del objeto recogido y el coste de transportarlo hasta la base. Cada par de zapatos tiene un peso determinado que afecta a la velocidad de movimiento del personaje; cuanto mayor sea el peso transportado, más lento se moverá el avatar. Además, los jugadores deben esquivar al NPC, que lanzará proyectiles capaces de paralizarlos temporalmente.

El prototipo permitirá:
### 3.A. Entorno
   El escenario de trata de un mundo virtual con una malla de navegación proporcionada por Unity. Los objetos recolectables están distribuidos en puntos concretos del mapa y existen dos personajes que pueden ser controlados tanto por IA como por un jugador humano. Además, hay un NPC situado en una de las esquinas de la mapa.
   En el escenario cuanta de una cámara general fija, cámaras de tercera persona que seguirán a cada personaje y un botón en la interfaz de usuario para cambiar entre distintos modos de observación.
### 3.B. Movimiento del personaje
   El agente controlable (Beastie) aparece inicialmente en su base. Puede desplazarse por el escenario caminando o corriendo y realizar acciones de recoger y soltar zapatos.
   La velocidad de movimiento depende del peso del objeto transportado, lo que obligará al jugador tomar decisiones estratégicas entre el valor del objeto y la movilidad.
### 3.C. NPC
   El NPC (Tux) implementa su comportamiento mediante un **árbol de comportamiento**. Navega alrededor de la mapa usando la malla de navegación de Unity y, cada cierto tiempo, realiza disparos a los juagadores. La selección del objetivo se realiza en función de la puntuación del avatar y de la distancia entre el NPC y el jugador.
   Los proyectiles aplican un efecto que paraliza el movimiento del jugador durante un tiempo determinado.
### 3.D. Bots
   Los personajes cosntrolados por IA (Beastie) se implementa utilizando técnicas:
   - GOAP(Goal-Oriented Action Planning).
   - Machine learning.
   Estos agentes deben tomar decisiones para optimizar la recogida y transporte de objetos.

### 3.E. Métricas
   El objetivo es maximizar la puntuación obtenida por cada avatar. Para ello, los agentes deben decidir la acción valorando:
   - Puntuación de los objetos recogidos.
   - Peso transportado.
   - Tiempo necesario para llevar el objeto hasta la base.
   - Riesgo de ser paralizado por el NPC.

## 4. Diseño de la solución

El proyecto contará con tres escenas:
- **Escena inicial:** menú de inicio de la simulación, que tendrá un botón para iniciar la partida.
- **Escena principal:** simulación del juego.
- **Escena final:** mostrará las puntuaciones de los bots e incluirá botones para salir o reiniciar la simulación.

### 4.1. Controles
|Input|Función|Jugador|
|--|--|--|
|WASD|Movimiento|1|
|Shift izquierdo|Correr|1|
|E|Soltar|1|
|Flechas|Movimiento|2|
|Numpad 1|Correr|2|
|Numpad 3|Soltar|2|

### 4.2. HUD
| Elemento | Tipo | Funcionalidad |
|----------|------|--------------|
| Cam. fija | Botón | Coloca la cámara en una posición y rotación predeterminadas. |
| Pantalla dividida | Botón | La pantalla se dividirá en dos, cambiando de la cámara principal a las cámaras de los dos bots |
| Puntuaciones | Texto | Indirá la puntuacción actual de los dos bots |
| Salir | Botón | Cerrar el programa |
| Reiniciar | Botón | Reiniciar la simulación |
| Temporizador | Texto | Un cuenta atrás que indicará cuanto tiempo queda para finalizar la simulación |

### 4.3. Comportamientos implementados

#### 4.3.1 Beastie rojo
   Utilizará machine learning para aprender que acciones le resultaran una mayor puntuación. Al realizar la simulación una serie de veces, el Beastie rojo deberá ser capaz de rocojer zapatos y devolverlos a su base, llevando en cuenta el tiempo que ha tardado en devolver el zapato y su valor.

**Algo**
- Descripcion.
- Características:
	1. x
- Pseudocódigo:
``` csharp
class Hola
```
#### 4.3.2 Beastie morado
   Utilizará GOAP para la recogida de zapatos.

#### 4.3.3 Tux 
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
1. Desde menú inicial, entrar al juego pulsando el botón `Start`:
   - Confirmar que aparece un panel que muestra dos avatares. 
   - Confirmar que puedes elegir entre `Human` y `AI`.
2. Después de elegir el tipo para los dos avatares, al pulsar el botón `Play` te lleva a la escena de juego seleccionado los prefabs correspondientes.
   - Confirmar que los avatares se colocan en su base correspondiente.
3. Tener al menos un avatar `Human` e intentar coger un zapato.
   - Confirmar que el zapato aparece por encima del avatar y ralentiza al jugador al caminar.
   - Confirmar que sólo se puede coger un par de zapatos a la vez.
   - Confirmar que se suelta los zapatos (si los hay) pulsando los controles correspondientes.
4. Teniendo un par de zapatos cogido, llegar a una base.
   - Comprobar que solo se destruye los zapatos y se acumulan puntos cuando el avatar llega a su base.
5. En la escena de juego, aparece un botón `Change Camera` y otro de `Exit`.
   - Comprobar que, al clicar al primer botón, se cambia la cámara.
   - Comprobar que, al clicar al segundo botón, se cierra el programa.

**Apartado B.**
1. Después de elegir dos prefabs de `Human`, al pulsar el botón `Play` te lleva a la escena de juego seleccionado los prefabs correspondientes.
   - Confirmar que los controles de movimiento funcionan.
2. Tener al menos un avatar `Human` e intentar coger un zapato.
   - Confirmar que el zapato aparece por encima del avatar y ralentiza al jugador al caminar.
   - Confirmar que sólo se puede coger un par de zapatos a la vez.
   - Confirmar que se suelta los zapatos (si los hay) pulsando los controles correspondientes.
3. Teniendo un par de zapatos cogido, llegar a una base.
   - Comprobar que solo se destruye los zapatos y se acumulan puntos cuando el avatar llega a su base.
4. En la escena de juego, aparece un botón `Change Camera` y otro de `Exit`.
   - Comprobar que, al clicar al primer botón, se cambia la cámara.
   - Comprobar que, al clicar al segundo botón, se cierra el programa.

**Apartado C.**
TUX

**Apartado D.**
GOAP 
Machine Learning

**Apartado E.**
1. Confirmar que al depositar un par de zapatos, la puntación correspondiente se suma al avatar específico.
2. Verificar que todas las métricas se muestran y se actualizan correctamente en el HUD.



## 7. Conclusión
En este proyecto, se ha desarrollado un prototipo funcional que integra distintos conceptos fundamentales de la Inteligencia Artificial aplicada a videojuegos dentro de un entorno interactivo en Unity. A través del escenario, se han implementado y combinado técnicas clásicas de **decisión** como **Árboles de Comportamiento**, **GOAP (Goal Oriented Action Planning)** y **ML (Machine Learning)**. Además, se han experimentado técnicas de navegación usando la malla de **navegación** que ofrece Unity combinada con el uso de waypoints.

Uno de los aspectos más peculiares ha sido la **comparación entre distintas herramientas y metodologías** ampliamente utilizadas en la industria. Esto nos ha permitido comprender mejor sus diseños, analizar sus diferencias y conocer en qué situaciones resulta más conveniente utilizar cada una. Ha sido una experiencia muy enriquecedora trabajar con enfoques nuevos y experimentar directamente con ellos.

Asimismo, la incorporación de métricas ha permitido observar cómo actúan nuestros agentes en diferentes situaciones. Gracias a estos datos, hemos podido identificar posibles mejoras y detectar comportamientos que podrían optimizarse o modificarse en futuras versiones.

Durante el desarrollo también se han abordado problemas típicos relacionados con la toma de decisiones, la navegación de agentes y la integración de distintos sistemas de IA dentro de un mismo entorno.

En conjunto, este proyecto no solo cumple los objetivos planteados, sino que también sirve como una base sólida para futuras ampliaciones y experimentación. Además, el proceso de desarrollo nos ha permitido aprender una gran cantidad de conceptos y técnicas relacionadas con la Inteligencia Artificial aplicada a videojuegos, aumentando todavía más nuestro interés y motivación por seguir profundizando en este campo.



## 8. Evolución y distribución

### María Eduarda Beckers
| Fecha | Descripción |
|----------|------|
| 2026-05-12 | *Documentación*: s |

### Haoshuang Hou
| Fecha | Descripción |
|----------|------|
| 2026-05-12 | *Documentación*: s |

### Bingcheng Wang
| Fecha | Descripción |
|----------|------|
| 2026-05-10 | *Organización*: Creación del repositorio y README |
| 2026-05-11 | *Desarrollo*: Creación del proyecto de Unity |

## 9. Licencia
- Uso educativo y de investigación – Universidad Complutense de Madrid
- Copyright (c) 2026 María Eduarda Beckers, Haoshuang Hou, Bingcheng Wang
- Se concede permiso permanente a los profesores de la Facultad de Informática de la Universidad Complutense de Madrid para utilizar, reproducir, modificar o distribuir total o parcialmente este material (código) con fines exclusivamente educativos o de investigación.
- Se permite el uso de datos derivados de forma agregada y anónima, así como la inclusión del material en trabajos académicos, siempre con reconocimiento expreso de los autores.
- Esta licencia no otorga derechos de uso comercial ni de explotación fuera del ámbito académico o de investigación, salvo autorización expresa de los autores.
- Arte, música y recursos audiovisuales: todos los assets han sido creados por los autores del proyecto y se distribuyen exclusivamente bajo las mismas condiciones de uso educativo y de investigación descritas anteriormente, quedando prohibido su uso comercial sin autorización expresa.

## 10. Referencias
