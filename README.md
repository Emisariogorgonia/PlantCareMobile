# 🤝 Guía de Colaboración y Flujo de Trabajo (FAVOR DE LEER COMPLETO)

Para asegurar la calidad del proyecto y evitar conflictos que detengan nuestro progreso (como errores en producción o código sobreescrito), decidi que seria bueno adoptar un flujo de trabajo basado en **Ramas (Feature Branch Workflow)**.

## 📌 Reglas Generales
1.  **La rama `main` es sagrada:** Nunca se hace `push` directo a `main`. Esta rama solo debe contener código funcional y aprobado.
2.  **Una tarea = Una rama:** Cada nueva funcionalidad o corrección de error debe desarrollarse en su propia rama independiente.
3.  **Code Review:** Todo cambio debe pasar por un *Pull Request (PR)* antes de integrarse.

---

## 🛠️ Guía Paso a Paso para Desarrollar

Sigue estos pasos cada vez que inicies una nueva tarea:

### 1. Actualiza tu repositorio local
Antes de crear cualquier rama, asegúrate de tener la última versión del proyecto para evitar conflictos de fusión.

```bash
git checkout main
git pull origin main
```

### 2. Crea tu rama de trabajo
Crea una rama nueva a partir de main. Usa un nombre descriptivo siguiendo estas convenciones:
-_feature/nombre-funcionalidad (para cosas nuevas)_
-_fix/nombre-error (para arreglar bugs)_
-_docs/descripcion (para documentación)_

### Ejemplo:
Si vas a trabajar en el login:
`_git checkout -b feature/login-usuario_`

### 3. Trabaja y guarda tus cambios
Realiza tus cambios en el código. Haz commits pequeños y con mensajes claros:
```bash
git add.
git commit -m "Agrega validación de correo en el login"
```

### 4. Sube tu rama a GitHub
Una vez termines, sube tu rama al repositorio remoto. NO intentes subir a main.
```bash
git push origin feature/login-usuario
```

### 5. Crea un Pull Request (PR)
1. Ve a la página del repositorio en GitHub.
2. Verás un aviso reciente de tu rama con un botón verde "Compare & pull request".
3. Haz clic, escribe una breve descripción de lo que hiciste y asigna a un compañero para que revise el código (Reviewer).
4. Una vez aprobado, se hará el Merge a main.

***Atte. Su buen amigo 
-El Hombre Araña***
