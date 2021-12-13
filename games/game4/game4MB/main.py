from graphics import *
from other_tools import *

from MarioBros.reference import *

import pygame
import time

def verificarEvento_redimension(event):
    if event.type == pygame.VIDEORESIZE:
        resize(event.w, event.h)
        try:
            windowResizing(event) #from reference.py (project)
        except: pass
            
def verificarEvento_salir(event):
    if event.type == pygame.QUIT:
        try:
            windowClosing() #from reference.py (project)
        except: pass

def verificarEventos_teclado(event):
    try:
        KeyPressed(event) #from reference.py (project)
    except: pass
    try:
        KeyReleased(event) #from reference.py (project)
    except: pass
        
def verificarEventos_mouse(event):
    try:
        MousePressed(event) #from reference.py (project)
    except: pass
    try:
        MouseReleased(event) #from reference.py (project)
    except: pass
    try:
        MouseMotion(event) #from reference.py (project)
    except: pass
    
def verificarEventos():
    for event in pygame.event.get():
        verificarEvento_salir(event)
        verificarEvento_redimension(event)
        verificarEventos_teclado(event)
        verificarEventos_mouse(event)

descanso_por_fotograma = [0]

def calibrarDescansoPorFotograma():
    c = (frameRateAverage() / frameRate()-1) / (2 * frameRate())
    descanso_por_fotograma[0] += c
    if descanso_por_fotograma[0] > 1 / frameRate():
        descanso_por_fotograma[0] = 1 / frameRate()
            
def update():
    pygame.display.update()
    updateMouse() #from graphics.py
    if(update_fps()):
        calibrarDescansoPorFotograma()
    verificarEventos()
    
if __name__ == '__main__':
    
    descanso_por_fotograma[0] = 1 / frameRate() #frameRate() is from graphics.py
    
    try: 
        setup() #from reference.py (project)
    except: printErr("setup() no se ha podido completar correctamente")
    
    while enEjecucion():
        inicioCicloFotograma = time.time()
        
        update() 
        
        resetGraphics() #from graphics.py
        draw() #from reference.py (project)
        
        pygame.display.flip()
        
        duracion_cicloFotograma = time.time()-inicioCicloFotograma
        descansar = descanso_por_fotograma[0]-duracion_cicloFotograma
        
        if(descansar > 0):
            time.sleep(descansar)