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


## Try it on the web:
* **[Here]( https://fontidar.github.io/Intermidiate-Axis-Theorem-simulation/)** 
---


## Theory:

Simulation based on the Euler ecuations for rigid bodys:

$$I_1 \dot{\omega}_1 + (I_3 - I_2) \omega_2 \omega_3 = M_1$$

$$I_2 \dot{\omega}_2 + (I_1 - I_3) \omega_3 \omega_1 = M_2$$

$$I_3 \dot{\omega}_3 + (I_2 - I_1) \omega_1 \omega_2 = M_3$$

Where we solve for $$\dot{\omega}_i$$ on void ($$M_i = 0 \space \forall \space i \in (1,2,3) $$)

Solved with RungeKutta-4 Method. For fast and fairly acurrate solutions.
