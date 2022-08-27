Public Class Idioma

    Public Class Ingles
        Shared Sub LANG_English()
            'SignUp Form
            SignUP.Text = "Register | Wor: FileBox"
            SignUP.Label1.Text = "Sign Up"
            SignUP.Label2.Text = "User Name"
            SignUP.Label3.Text = "Password"
            SignUP.Label4.Text = "Email"
            SignUP.Button1.Text = "Sign Up"

            'SignIn Form
            SignIN.Text = "Log in | Wor: FileBox"
            SignIN.Label1.Text = "Sign In"
            SignIN.Label2.Text = "User Name"
            SignIN.Label3.Text = "Password"
            SignIN.Label4.Text = "Have you forgotten your Password?"
            SignIN.Button1.Text = "Sign In"

            'Filebox Form
            FileBox.Label1.Text = "File Protector"
            FileBox.Label2.Text = "File list"
            FileBox.BTN_NewFile.Text = "New File"
            FileBox.BTN_RemoveFile.Text = "Remove File"
            FileBox.BTN_PNL_SaveChanges.Text = "Save Changes"
            FileBox.BTN_PNL_SaveChangesAndClose.Text = "Save and Close"
            FileBox.Button1.Text = "Open File"
            FileBox.BTN_PNL_CloseFile.Text = "Close File"
            FileBox.SeparatorToolStripMenuItem.Text = "Separator"
            FileBox.RemoveFileToolStripMenuItem.Text = "Remove"
            FileBox.MoveToDesktopToolStripMenuItem.Text = "Move to Desktop"
            FileBox.CopyToDesktopToolStripMenuItem.Text = "Copy to Desktop"
            FileBox.BuscarToolStripMenuItem.Text = "Search"
            FileBox.ReloadToolStripMenuItem.Text = "Reload"
            FileBox.BackupToolStripMenuItem.Text = "Backup"
            FileBox.LlaveCriptograficaToolStripMenuItem.Text = "Cryptography Key"
            FileBox.AboutToolStripMenuItem.Text = "About"
            FileBox.ExitToolStripMenuItem.Text = "Exit"

            'CryptoKey Form
            ChangeCryptoKey.Text = "Cryptography Key | Wor: FileBox"
            ChangeCryptoKey.Label1.Text = "Cryptography Key"
            ChangeCryptoKey.Label2.Text = "The Cryptographic Key is a key to be able to Encrypt and Decrypt the Files, it can not be repeated, it is unique, and nobody else can have"
            ChangeCryptoKey.Label3.Text = "Your cryptographic key is"
            ChangeCryptoKey.GroupBox1.Text = "See the Current Cryptographic Key"
            ChangeCryptoKey.GroupBox2.Text = "Change the Cryptographic Key"
            ChangeCryptoKey.Button1.Text = "Show"
            ChangeCryptoKey.Button2.Text = "Generate Automatically"
            ChangeCryptoKey.Button3.Text = "Write a New"

            'BackUp Form
            BackUp.Text = "Backups | Wor: FileBox"
            BackUp.Label1.Text = "Backup Manager"
            BackUp.Label2.Text = "From here you can create and read backup copies" &
                vbCrLf & "When creating a backup will be created on the desktop, fully encrypted, you must remember your encryption key" &
                vbCrLf & "When reading a backup you must indicate the encryption key to open the backup"
            BackUp.Label3.Text = "Create backup"
            BackUp.Label4.Text = "A backup copy of your files will be created in a folder that will be placed in your Desktop folder" &
                vbCrLf & "You will be prompted with a new encryption key which will not be the same as the current encryption key"
            BackUp.Label5.Text = "Read Backup"
            BackUp.Label6.Text = "Drag and Drop the backup into your original Folder (FileBoxArchives)" &
                vbCrLf & "Then enter the encryption key to be able to read the backup copy"
            BackUp.Label7.Text = "When reading the Backup copy all your current files will be deleted"
            BackUp.Label8.Text = "When you create the backup, you can still access your files"
            BackUp.TabPage1.Text = "Create Backup"
            BackUp.TabPage1.Text = "Read Backup"
            BackUp.Button1.Text = "Create Backup"

            'About Form
            About.Label2.Text = "File Protector"
            About.Label3.Text = "Wor: FileBox is an application that allows you to protect your most private files from others, with a strong encryption system to avoid intruders." &
            vbCrLf & "Feel free to write your most private notes in FileBox, they will be secure and protected." &
            vbCrLf & "Features:" &
            vbCrLf & "   -DragAndDrop: Drag and Drop your files in the File List to protect them" &
            vbCrLf & "   -Backup: Create totally secure and encrypted backups, you can also read one from the form 'BackUp'" &
            vbCrLf & "   -CryptoActions: SistemTrail module which is concerned with protecting and keeping your files safe" &
            vbCrLf & "   -SignON: Register and Log in, this way only you can access the protected files"
            About.LinkLabel1.Text = "Support"
            About.Label4.Text = "*Community Standard: AppSupport was Natively Added for the Application"
        End Sub
    End Class

    Public Class Español
        Shared Sub LANG_Español()
            'SignUp Form
            SignUP.Label1.Text = "Registrarse"
            SignUP.Label2.Text = "Nombre de Usuario"
            SignUP.Label3.Text = "Contraseña"
            SignUP.Label4.Text = "Correo"
            SignUP.Button1.Text = "Registrarme"

            'SignIn Form
            SignIN.Label1.Text = "Iniciar sesión."
            SignIN.Label2.Text = "Nombre de Usuario"
            SignIN.Label3.Text = "Contraseña"
            SignIN.Label4.Text = "¿Olvidaste tu Contraseña?"
            SignIN.Button1.Text = "Iniciar sesión"

            'Filebox Form
            FileBox.Label1.Text = "Protector de Archivos"
            FileBox.Label2.Text = "Lista de Archivos"
            FileBox.BTN_NewFile.Text = "Nuevo Archivo"
            FileBox.BTN_RemoveFile.Text = "Remover Archivo"
            FileBox.BTN_PNL_SaveChanges.Text = "Guardar Cambios"
            FileBox.BTN_PNL_SaveChangesAndClose.Text = "Guardar y Cerrar"
            FileBox.Button1.Text = "Abrir"
            FileBox.BTN_PNL_CloseFile.Text = "Cerrar Archivo"
            FileBox.SeparatorToolStripMenuItem.Text = "Separador"
            FileBox.RemoveFileToolStripMenuItem.Text = "Remover"
            FileBox.MoveToDesktopToolStripMenuItem.Text = "Mover al Escritorio"
            FileBox.CopyToDesktopToolStripMenuItem.Text = "Copiar al Escritorio"
            FileBox.BuscarToolStripMenuItem.Text = "Buscar"
            FileBox.ReloadToolStripMenuItem.Text = "Recargar"
            FileBox.BackupToolStripMenuItem.Text = "Copia de Seguridad"
            FileBox.LlaveCriptograficaToolStripMenuItem.Text = "Llave criptográfica"
            FileBox.AboutToolStripMenuItem.Text = "Sobre FileBox"
            FileBox.ExitToolStripMenuItem.Text = "Salir"

            'CryptoKey Form
            ChangeCryptoKey.Text = "Llave criptográfica | Wor: FileBox"
            ChangeCryptoKey.Label1.Text = "Llave criptográfica"
            ChangeCryptoKey.Label2.Text = "La Llave Criptográfica es una clave para poder encriptar y des-encriptar los archivos, no se puede repetir, es única, y nadie más puede tenerla."
            ChangeCryptoKey.Label3.Text = "Llave criptográfica es"
            ChangeCryptoKey.GroupBox1.Text = "Ver la llave criptográfica Actual"
            ChangeCryptoKey.GroupBox2.Text = "Cambiar la llave criptográfica"
            ChangeCryptoKey.Button1.Text = "Mostrar"
            ChangeCryptoKey.Button2.Text = "Generar Automaticamente"
            ChangeCryptoKey.Button3.Text = "Escribir una Nueva"

            'BackUp Form
            BackUp.Text = "Copias de Seguridad | Wor: FileBox"
            BackUp.Label1.Text = "Copia de Seguridad"
            BackUp.Label2.Text = "Desde aqui puede crear y leer copias de seguridad" &
                vbCrLf & "Al Crear una backup se creará en el escritorio, totalmente encriptada, debe recordar su Llave de Cifrado." &
                vbCrLf & "Al Leer una backup debe indicar la llave de cifrado para poder abrir la Backup."
            BackUp.Label3.Text = "Crear una Copia de Seguridad"
            BackUp.Label4.Text = "Se creará una copia de seguridad de tus archivos en una carpeta que se creará en tu Escritorio." &
                vbCrLf & "Se te indicará  una nueva llave de cifrado la cual no será igual a la llave de cifrado actual."
            BackUp.Label5.Text = "Leer una Copia de Seguridad"
            BackUp.Label6.Text = "Arrastre y Suelte la copia de seguridad en su carpeta original (FileBoxArchives)" &
                vbCrLf & "Luego ingrese la llave de cifrado para poder leer la copia de seguridad"
            BackUp.Label7.Text = "Al leer la Copia de Seguridad todos tus archivos actuales serán eliminados."
            BackUp.Label8.Text = "Al crear la copia de seguridad, todavía podrás acceder a tus archivos."
            BackUp.TabPage1.Text = "Crear Backup"
            BackUp.TabPage1.Text = "Leer Backup"
            BackUp.Button1.Text = "Crear Copia de Seguridad"

            'About Form
            About.Label2.Text = "Protector de Archivos"
            About.Label3.Text = "Wor: FileBox es una aplicación que te permite proteger tus archivos más privados de los demás, con un sistema de encriptación propio y fuerte para evitar a los intrusos." &
            vbCrLf & "Siéntete libre de escribir tus notas más privadas en FileBox, estarán seguras y protegidas." &
            vbCrLf & "Características:" &
            vbCrLf & "   -DragAndDrop: Arrastra y Suelta tus archivos en la lista de archivos para protegerlos." &
            vbCrLf & "   -Backup: Crea copias de seguridad totalmente seguras y encriptadas, también puedes leer una desde el formulario 'BackUp'." &
            vbCrLf & "   -CryptoActions: Modulo propio de SistemTrail la cual se preocupará  de proteger y mantener seguros tus archivos" &
            vbCrLf & "   -SignON: Registrate e Inicia Sesión, de esta manera solo tu podrás acceder a los Archivos protegidos."
            About.LinkLabel1.Text = "Soporte"
            About.Label4.Text = "Comunidad: AppSupport fue Agregado de forma Nativa para la Aplicacion"
        End Sub
    End Class
End Class