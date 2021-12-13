from graphics import *
import math

from custom_math import *
from file_management import *
from other_tools import *

def setup():    
    title("reference - Jeffrey Agudelo")
    
def draw():
    background(0xffffff)
    color(0)
    translate([dimCanvas[0] / 2, dimCanvas[1] / 2])
    straight(0, 0, 0, 1)
    straight(0, 0, 1, 0)
    circle(mouseTX(), mouseTY(), getSpeedMouse())
    txt = "fps: " + str(frameRateAverage())
    drawText(txt, 2, 2, izquierda, false)
    
#--------------------------EVENTOS TECLADO-----------------------------------
    
def KeyPressed(event):
    if event.type == pygame.KEYDOWN:
        if event.key == pygame.K_RIGHT: # -----derecha presionado-----
            pass
        if event.key == pygame.K_LEFT: # -----izquierda presionado-----
            pass
        if event.key == pygame.K_UP: # -----arriba presionado-----
            pass
        if event.key == pygame.K_DOWN: # -----abajo presionado-----
            pass
        if event.key == pygame.K_SPACE: # -----espacio presionado-----
            pass
            
def KeyReleased(event):
    if event.type == pygame.KEYUP:
        if event.key == pygame.K_RIGHT: # -----derecha liberado-----
            pass
        if event.key == pygame.K_LEFT: # -----izquierda liberado-----
            pass
        if event.key == pygame.K_UP: # -----arriba liberado-----
            pass
        if event.key == pygame.K_DOWN: # -----abajo liberado-----
            pass
        if event.key == pygame.K_SPACE: # -----espacio liberado-----
            pass
            
#--------------------------EVENTOS MOUSE-----------------------------------

def MousePressed(event):
    if event.type == pygame.MOUSEBUTTONDOWN:
        mouseInWindow = event.pos
        mouseInGraphics = getMouseTransform()
        if event.button == 1: # -----boton izquierdo presionado-----    
            pass
        if event.button == 2: # -----boton scroll presionado-----
            pass
        if event.button == 3: # -----boton derecho presionado-----
            pass
        if event.button == 4: # -----scroll avanza-----
            pass
        if event.button == 5: # -----scroll retrocede-----
            pass
            
def MouseReleased(event):
    if event.type == pygame.MOUSEBUTTONUP:
        mouseInWindow = event.pos
        mouseInGraphics = getMouseTransform()
        if(event.button == 1): # -----boton izquierdo liberado-----
            pass
        if event.button == 2: # -----boton scroll liberado-----
            pass
        if event.button == 3: # -----boton derecho liberado-----
            pass
        if event.button == 4: # -----scroll avanza-----
            pass
        if event.button == 5: # -----scroll retrocede-----
            pass
            
def MouseMotion(event):
    if event.type == pygame.MOUSEMOTION:
        mouseInWindow = event.pos
        mouseInGraphics = getMouseTransform()
        if(event.buttons[0] == 1): # -----arrastrando con el boton izquierdo-----
            pass
        if event.buttons[1] == 1: # -----arrastrando con el scroll-----
            pass
        if event.buttons[2] == 1: # -----arrastrando con el boton derecho-----
            pass
           
#--------------------------EVENTOS VENTANA-----------------------------------
            
def windowResizing(event):# -----ventana redimensionada-----
    pass

def windowClosing():
    print("Adios...")
    exit()