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
El Beastie Rojo utiliza aprendizaje por refuerzo mediante ML-Agents de Unity para aprender automáticamente una política de comportamiento orientada a maximizar la puntuación final de la partida.

A diferencia de un comportamiento programado manualmente, el agente aprende mediante prueba y error interactuando con el entorno. Durante el entrenamiento, el Beastie ejecuta acciones, recibe recompensas o penalizaciones y ajusta progresivamente su política para mejorar su rendimiento.

El objetivo del entrenamiento consiste en que el agente aprenda estrategias eficientes para:

- Recoger zapatos valiosos.
- Minimizar el tiempo de transporte.
- Evitar ser alcanzado por Tux.
- Gestionar el peso transportado.
- Optimizar la puntuación total obtenida antes de finalizar la partida.

Para entrenar al Beastie Rojo utilizando ML-Agents, es necesario instalar tanto el paquete de Unity como el entorno Python encargado del entrenamiento.

##### Configuración del agente en Unity

El Beastie Rojo utiliza un prefab con varios componentes específicos de ML-Agents.

| Componente          | Función                                       |
| ------------------- | --------------------------------------------- |
| Behavior Parameters | Define el espacio de observaciones y acciones |
| Decision Requester  | Indica cada cuántos frames toma decisiones    |
| Agent Script        | Script principal del aprendizaje              |
| Rigidbody           | Movimiento físico                             |
| Collider            | Detección de colisiones                       |

##### Diseño del agente
La clase principal "Beastie Agent" heredará de Agent. Tenniendo los siguientes métodos:

| Método                  | Función                             |
| ----------------------- | ----------------------------------- |
| `CollectObservations()` | Recoge información del entorno      |
| `OnActionReceived()`    | Ejecuta acciones                    |
| `OnEpisodeBegin()`      | Reinicia el episodio                |
| `Heuristic()`           | Permite control manual para pruebas |


**Observaciones utilizadas:**
- Posición relativa del zapato más cercano.
- Distancia al zapato.
- Peso del zapato.
- Valor del zapato.
- Si actualmente lleva un zapato.
- Peso transportado actual.
- Posición relativa de la base.
- Distancia a la base.
- Posición relativa de Tux.
- Distancia a Tux.
- Velocidad actual.
- Tiempo restante de la partida.

Ejemplo:

```csharp
public override void CollectObservations(VectorSensor sensor)
{
    sensor.AddObservation(relativeShoePosition);
    sensor.AddObservation(shoeWeight);
    sensor.AddObservation(shoeValue);
    sensor.AddObservation(hasShoe ? 1 : 0);
    sensor.AddObservation(relativeBasePosition);
    sensor.AddObservation(relativeTuxPosition);
    sensor.AddObservation(currentVelocity);
}
```

**Espacio de acciones (Action Space):**

| Rama            | Acción                            |
| --------------- | --------------------------------- |
| Movimiento      | Arriba, abajo, izquierda, derecha |
| Acción especial | Nada, recoger/soltar              |

```csharp
int moveAction = actions.DiscreteActions[0];
int interactAction = actions.DiscreteActions[1];
```

**Sistema de Recompensas:**
El Beastie recibe recompensas positivas por comportamientos deseados y penalizaciones por acciones perjudiciales.

| Evento                              | Recompensa           |
| ----------------------------------- | -------------------- |
| Recoger zapato                      | `+0.5f`              |
| Entregar zapato                     | `+(valorZapato * 2)` |
| Acercarse a la base llevando zapato | `+0.01f`             |
| Estar mucho tiempo sin actuar       | `-0.001f`            |
| Transportar mucho peso              | `-0.0005f * peso`    |
| Ser golpeado por Tux                | `-1.0f`              |
| Chocar contra obstáculos            | `-0.1f`              |

```csharp
AddReward(valorZapato * 2f);
```

##### Entrenamiento del modelo

Para comenzar el entrenamiento se utiliza un archivo de configuración YAML y la terminal.

```yaml
behaviors:
  BeastieBehavior:
    trainer_type: ppo
    hyperparameters:
      batch_size: 1024
      buffer_size: 10240
      learning_rate: 3.0e-4
    network_settings:
      hidden_units: 128
      num_layers: 2
    reward_signals:
      extrinsic:
        gamma: 0.99
        strength: 1.0
    max_steps: 500000
    time_horizon: 64
    summary_freq: 10000
```
```bash
mlagents-learn config.yaml --run-id=BeastieTraining
```


#### 4.3.2 Beastie morado
**GOAP (Goal-Oriented Action Planning)**
El Beastie Morado utiliza **GOAP** para la recogida de zapatos. 
- GOAP es un sistema de planificación de IA donde el agente no sigue un árbol de comportamiento fijo, sino que construye planes dinámicamente encadenando acciones para alcanzar una meta. El planificador usa el algoritmo **A estrella** para encontrar la secuencia óptima de acciones que transforme el estado actual del mundo en el estado deseado, minimizando el coste total.
- Características:
	1. *Orientación a metas*: El agente no sigue una secuencia fija de comportamientos, sino que identifica su objetivo actual y construye un plan para alcanzarlo.
   2. *Planificación dinámica*: Recalcula su plan cuando las condiciones del entorno cambian significativamente, adaptándose a nuevas situaciones sin necesidad de programar cada caso.
   3. *Optimización por costes*: Evalúa múltiples caminos posibles para alcanzar su meta y selecciona el de menor coste, considerando factores.
   4. *Independencia entre acciones y metas*: Las acciones se definen de forma modular con sus propias precondiciones y efectos, permitiendo que el planificador las combine libremente para satisfacer distintas metas.
   5. *Reacción a eventos externos*: Si hay un evento externo, deja el plan actual y replanifica desde el nuevo estado, demostrando capacidad de recuperación ante interrupciones.
- GOAP se sustenta en **tres elementos esenciales**:
   1. ESTADO DEL MUNDO: 
      - Representa una representación simplificada de la realidad del agente en un instante concreto. Es un conjunto de pares clave-valor (diccionario) donde cada clave describe una propiedad relevante del entorno o del propio agente, y el valor indica su estado actual.
      - El estado del mundo es la única información que el planificador necesita conocer para tomar decisiones, lo que lo hace muy eficiente. Solo se almacenan las variables relevantes para la toma de decisiones, ignorando detalles innecesarios del entorno.
      - Pseudocódigo:
      ``` csharp
      class WorldState:
         // dictionary (key: StateSO; value: State)
         states: []
    
         // verify if some conditions are true
         function MeetConditions(conditions:[]) -> bool:
            for c in conditions:
               if not states.containsKey(condition.key):
                  return false
               else if states[condition.key] != condition.value: 
                  return false
               else:
                  return true
         
         // apply effects and return a new state
         function ApplyEffects(effects:[]) -> WorldState :
            newState = Clone()
            for e in effects:
               newState.setState(e.key, e.value)
            return newState

         // clone a state
         function Clone() -> WorldState :
            clone = new WorldState()
            for par in states
               clone.states.add(par.key, par.value)
            return clone
      ```
   2. ACCIÓN: 
   - Representa una **operación atómica** que el agente puede realizar para transformar el estado actual del mundo en uno nuevo. Cada acción se define mediante tres componentes:
      1. *Precondiciones*: condiciones que deben cumplirse en el estado del mundo para que la acción pueda ejecutarse. Si el estado actual no satisface las precondiciones, el planificador ni siquiera considerará esta acción.
      2. *Efectos*: cambios en el estado del mundo una vez que la acción se completa con éxito. Modifican los valores de ciertas variables, añadiendo, cambiando o eliminando pares clave-valor.
      3. *Coste*: valor numérico (dinámico) que representa el gasto de ejecutar la acción. El planificador busca minimizar el coste total del plan, por lo que el coste determina la preferencia entre distintas secuencias.
   - Ejemplo:
   ```
   ACCIÓN "Recoger Zapato":
    Precondiciones: {
        zapatoCercano: true,     // Debe haber un zapato al alcance
        tieneZapato: false,      // No puede llevar ya uno
        paralizado: false        // No puede estar paralizado
    }
    
    Efectos: {
        tieneZapato: true,       // Ahora lleva un zapato
        zapatoCercano: false     // El zapato ya no está disponible
    }
    
    Coste: 1.5                   // Tiempo y peso del zapato
   ```
   - Pseudocódigo:
   ```csharp
   abstract class ActionGOAP
      // attributes
      nameAction: string
      cost: float = 1.0

      preconditions: Dict[]
      effects: Dict[]
      
      // verify if we can do this action in the current state
      function IsViable(currentState: WorldState) -> bool :
         return currentState.MeetConditions(preconditions)
      
      // execute action
      function Execute() -> bool :
      
      // verify if an action is finished
      function Finished() -> bool :
      
      // Get cost (it depends on the current state)
      function GetCost(currentState: WorldState) : float
         return cost
      
      // restart to reuse
      function Restart():

   ```
   3. META:
   - En GOAP, la meta no es una clase como tal, sino simplemente un diccionario de condiciones que el agente quiere cumplir. Es igual que las precondiciones o los efectos: pares de clave-valor.
   - Ejemplo:
   ```
   // La meta es simplemente un diccionario
   META "Entregar Zapato" = {
      tieneZapato: false,
      enBase: true
   }

   META "Sobrevivir" = {
      enPeligro: false
   }

   META "Recolectar" = {
      tieneZapato: true
   }
   ```
- Algoritmo principal de planificación
```csharp
function CreatePlan(currentState:WorldState, goal:[]) -> Action[] :
   // 1. If we've already reached the goal, do nothing
   if currentState.MeetsConditions(goal):
      return []  // Empty plan
   
   // 2. Try to build a plan using A*
   plan = AStarSearch(currentState, goal)
   
   if plan is not null:    // 3. If a plan was found, return it
      return plan
   else:    // 4. No plan found, return failure
      return FAILURE
```
- Búsqueda A*:
```csharp
struct PlanNode:
   state: WorldState // World state at this point
   action: Action // Action that led to this state
   parent: PlanNode // Previous node in the plan
   runningCost: float // Accumulated cost (g)
   estimatedCost: float // Total estimated cost (f = g + h)
   
function AStarSearch(initialState:WorldState, goal:[]) -> Action[] :
   // helper structures
   openList = []
   closedList = []
   
   // create the starting node
   startNode = PlanNode(state: initialState, action: null, parent: null, 
   runningCost: 0, estimatedCost: Heuristic(initialState, goal))
   
   Add(openList, startNode)
   
   while openList is not empty:
      // Pick the most promising node (lowest total estimated cost)
      currentNode = ExtractLowestCostNode(openList)
      
      // Check if we reached the goal
      if currentNode.state.MeetsConditions(goal):
         return ReconstructPlan(currentNode)
      
      // Mark as explored
      Add(closedList, currentNode)
      
      // Explore every available action
      for each action in AvailableActions:
         // Check if the action can run from this state
         if currentNode.state.MeetsConditions(action.preconditions):
               // Compute the new state after applying effects
               newState = currentNode.state.ApplyEffects(action.effects)
               
               // Compute costs
               newRunningCost = currentNode.runningCost + action.GetCost(currentNode.state)
               newEstimatedCost = newRunningCost + Heuristic(newState, goal)
               
               // Create the new node
               newNode = PlanNode(state: newState, action: action, parent: currentNode, 
               runningCost: newRunningCost, estimatedCost: newEstimatedCost)
               
               // Check if a node with the same state already exists in the open list
               existingOpenNode = FindNodeByState(openList, newState)
               existingClosedNode = FindNodeByState(closedList, newState)
               
               if existingOpenNode is not null:
                  // Replace if this path is cheaper
                  if newRunningCost < existingOpenNode.runningCost:
                     UpdateNode(existingOpenNode, newNode)
               
               else if existingClosedNode is not null:
                  // Reopen if we found a better path
                  if newRunningCost < existingClosedNode.runningCost:
                     Remove(closedList, existingClosedNode)
                     Add(openList, newNode)
               
               else:
                  // New node, add to the open list
                  Add(openList, newNode)
   
   // No solution found
   return null
```
- Heurística:
```csharp
// Counts how many goal conditions are still unsatisfied
// Assumes each action can satisfy at least one condition
function Heuristic(state: WorldState, goal: []) -> int :
   unsatisfied = 0
   
   for p in goal:
      if not state.containsKey(p.key) || state[key] != value:
         unsatisfied += 1
   return unsatisfied
```
- Reconstrucción de planes:
```csharp
// Walks backwards from the goal node to build the action sequence
function ReconstructPlan(finalNode: PlanNode) : Action[]
   plan = []
   currentNode = finalNode
   
   while currentNode.parent is not null:
      InsertAtFront(plan, currentNode.action)
      currentNode = currentNode.parent
   
   return plan
```
#### 4.3.3 Tux 
   El comportamiento de Tux estará controlado mediante un **Behaviour Tree (árbol de comportamiento)**, permitiendo gestionar tanto la navegación como el sistema de ataque de forma modular y escalable. 
   Tux aparecerá fuera del mapa, en una zona superior, y patrullará continuamente siguiendo una serie de puntos **(waypoints)**. Utilizará la malla de navegación de Unity para llegar al destino.

   Cada cierto tiempo disparará proyectiles hacia los Beasties. La selección del objetivo se realizará mediante una ponderación basada en la distancia al Beastie y la puntuación actual del Beastie.
   Se prioriza la acción de disparo frente a la navegación.
   - **Estructura base**
      ```csharp
      class Task:
         function run()->bool
      ```
      Nodos de control
      Son los que determina el flujo de ejecución del árbol.
      - Selector: Ejecuta los hijos en orden hasta que uno tenga éxito.
      - Sequence: Ejecuta todos los hijos en orden. Si uno falla, la secuencia falla.
      ```csharp
      class Selector extends Task:
         children: Task[]
         function run()->bool:
            for c in children:
               if c.run():
                  return true
            return false

      class Sequence extends Task:
         children: Task[]
         function run()->bool:
            for c in children:
               if not c.run():
                  return false
            return true
      ```
   - **Ataque**
      1. Tiempo de espera
      Comprueba si ha transcurrido el tiempo necesario para volver a disparar.
      ```csharp
      class Cooldown extends Task:
         children: Task[]
         function run() -> bool:
            if currentTime >= nextShootTime:
               return true
            return false
      ```
      2. Selección del objetivo
      La prioridad del objetivo se calcula mediante una ponderación entre la puntuación y la distancia: **P = score * w1 / distance * w2**, siendo *w1* y *w2* son pesos de cada uno de esos valores.
      ```csharp
      class SelectTarget extends Task:
         class BeastieInfo:
            score: float
         
         scoreWeight: float
         distanceWeight: float

         function run() -> bool:
            best = min
            for b in BeastieInfo:
               priority = b.score * scoreWeight / distanceTo(b) * distanceWeight

               if priority > best:
                  target = beastie
                  best = priority
            return true
      ```
      3. Disparo
      ```csharp
      class Shoot extends Task:
         function run() -> bool:
            direction = normalize(target.position - tux.position)
            shoot(direction)
            return true
      ```
   - **Navegación**
      1. Selección del siguiente punto
      ```csharp
      class NextWaypoint extends Task:
         function run() -> bool:
            if reached(currentWaypoint):
               currentWaypoint = path.next()
            return true
      ```
      2. Movimiento
      ```csharp
      class NextWaypoint extends Task:
         agent: NavMeshAgent
         function run() -> bool:
           agent.SetDestination(currentWaypoint.position)
         return true
      ```
   - **Diagrama**
   ```mermaid
   ---
   config:
   layout: fixed
   ---
   flowchart TB
      Init["Init"] --> A(("?"))
      A --> B(("->")) & C(("->")) & J("Siguiendo ruta")
      B --> D("Tiempo Superado?") & K["Selección del objetivo"] & L["Disparo"]
      C --> H("Waypoint alcanzado?") & I["Selección del Wayponit"]
   ```
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
1. Entrar en la escena de juego y observar el comportamiento de Tux.
   - Comprobar que Tux aparece en una de las esquinas del mapa.
   - Comprobar que Tux se desplaza correctamente entre los waypoints.
2. Esperar a que Tux ataque.
   - Comprobar que Tux realiza un disparo únicamente cuando ha superado el cooldown.
   - Comprobar que no dispara continuamente.
   - Comprobar que Tux selecciona objetivos en función de la distancia y puntuación.
   - Comprobar que Tux continúa moviendo cuando no puede disparar.
3. Cuando el proyectil colisiona con un avatar.
   - Comprobar que el proyectil al colisionar con Beastie lo paralice.
   - Comprobar que Beastie recupera el movimiento tras finalizar el tiempo de efecto.

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
| 2026-05-12 | *Documentación*: actualizar en conjunto el readme |
| 2026-05-14 | *Documentación*: añadir explicacion de ML |

### Haoshuang Hou
| Fecha | Descripción |
|----------|------|
| 2026-05-12 | *Documentación*: actualizar en conjunto el readme |
| 2026-05-15 | *Documentación*: añadir explicacion y pseudocódigo de árbol de comportamiento |
| 2026-05-15 | *Desarrollo*: crear HUD de puntuación e importar los modelos|

### Bingcheng Wang
| Fecha | Descripción |
|----------|------|
| 2026-05-10 | *Organización*: Creación del repositorio y README |
| 2026-05-11 | *Desarrollo*: Creación del proyecto de Unity |
| 2026-05-12 | *Documentación*: actualizar en conjunto el readme |
| 2026-05-14 | *Documentación*: añadir explicación y pseudocódigos de GOAP en el readme |

## 9. Licencia
- Uso educativo y de investigación – Universidad Complutense de Madrid
- Copyright (c) 2026 María Eduarda Beckers, Haoshuang Hou, Bingcheng Wang
- Se concede permiso permanente a los profesores de la Facultad de Informática de la Universidad Complutense de Madrid para utilizar, reproducir, modificar o distribuir total o parcialmente este material (código) con fines exclusivamente educativos o de investigación.
- Se permite el uso de datos derivados de forma agregada y anónima, así como la inclusión del material en trabajos académicos, siempre con reconocimiento expreso de los autores.
- Esta licencia no otorga derechos de uso comercial ni de explotación fuera del ámbito académico o de investigación, salvo autorización expresa de los autores.
- Arte, música y recursos audiovisuales: todos los assets han sido creados por los autores del proyecto y se distribuyen exclusivamente bajo las mismas condiciones de uso educativo y de investigación descritas anteriormente, quedando prohibido su uso comercial sin autorización expresa.

## 10. Referencias
- [Narratech](https://narratech.com/es/)
- [Descargarse ML-Agents Toolkit](https://docs.unity3d.com/Packages/com.unity.ml-agents@4.0/manual/Installation.html)
- [Canal de YouTube que enseña como descargar el ML-Agents Toolkit](https://www.youtube.com/@LudicWorlds)
- [Video tutorial de como usar el ML-Agents Toolkit](https://www.youtube.com/watch?v=zPFU30tbyKs)
- [Video tutorial de crear un árbol de comportamiento en Unity](https://www.youtube.com/watch?v=aR6wt5BlE-E)