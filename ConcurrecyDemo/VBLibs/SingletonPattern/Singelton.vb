Public Class Singleton
    Private Sub New()

    End Sub

    Public Shared ReadOnly Property GetInstance As Singleton
        Get
            Static Instance As Singleton = New Singleton
            Return Instance
        End Get
    End Property

End Class
