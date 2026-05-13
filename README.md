# Intermidiate Axis Theorem

[![Unity Version](https://img.shields.io/badge/Unity-6.0-blue.svg)](https://unity.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Unity physics 3D simulation of the intermidiate axis theorem and conservation of angular momentum on a rigid body by solving the Euler ecuations with a RungeKutta-4 method. 

---

## Features

* **Base Dzhanibekov effect simulation:**
  
  ![](.github/Media/Base_Simulation.gif)
* **Gizmos for better visualizacion:**

    ![](.github/Media/Additions.gif)
* **Parameter change during simulation:**
  
  ![](.github/Media/Parameters_Change.gif)
* **Grafics in real time:**
  
  ![](.github/Media/Graph.gif) 
* **Architecture:** Use of ScriptableObjects for data managment.


## Try it:
* **[On the web.]( https://fontidar.github.io/Intermidiate-Axis-Theorem-simulation/)** 
 
* **Or on your PC:**

 
 📦 **[Descargar Ejecutable para Windows/Mac](#)** ---



---


## 🔬 Fundamentos Teóricos / Matemáticos

Si tu simulación se basa en ecuaciones específicas, explícalas brevemente aquí. Por ejemplo:

La fuerza de atracción entre dos cuerpos se calcula usando la Ley de Gravitación Universal:

$$F = G \frac{m_1 m_2}{r^2}$$

* $F$ es la fuerza entre las masas.
* $G$ es la constante de gravitación.
* $r$ es la distancia entre los centros de las masas.

---

## ⚙️ Requisitos y Configuración

Si decides clonar el repositorio para modificar el código:

1.  **Unity Version:** `2022.3.X LTS` (o la que uses).
2.  **Render Pipeline:** URP / HDRP / Built-in.
3.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/tu-repositorio.git](https://github.com/tu-usuario/tu-repositorio.git)
    ```

---

## 🕹️ Controles de la Simulación

| Tecla / Acción | Función |
| :--- | :--- |
| `Click Izquierdo` | Interactuar / Aplicar fuerza al objeto |
| `Espacio` | Pausar / Reanudar la simulación |
| `R` | Reiniciar el escenario a los valores por defecto |
| `UI Sliders` | Ajustar la gravedad y la escala de tiempo |

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
