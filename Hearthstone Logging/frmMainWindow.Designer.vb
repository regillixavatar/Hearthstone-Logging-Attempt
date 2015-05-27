<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnStartLogging = New System.Windows.Forms.Button()
        Me.btnCloseProgram = New System.Windows.Forms.Button()
        Me.cbxTurnList = New System.Windows.Forms.ComboBox()
        Me.btnGetTurn = New System.Windows.Forms.Button()
        Me.txtPlayerName = New System.Windows.Forms.TextBox()
        Me.lblPlayerName = New System.Windows.Forms.Label()
        Me.btnPauseLogging = New System.Windows.Forms.Button()
        Me.cbxGameList = New System.Windows.Forms.ComboBox()
        Me.lblCardPlayedList = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCardsPlayed = New System.Windows.Forms.TabPage()
        Me.lblNumAttacks = New System.Windows.Forms.Label()
        Me.txtNumAttacks = New System.Windows.Forms.TextBox()
        Me.lblCardTarget = New System.Windows.Forms.Label()
        Me.txtCardTarget = New System.Windows.Forms.TextBox()
        Me.lblTurnPlayed = New System.Windows.Forms.Label()
        Me.txtTurnPlayed = New System.Windows.Forms.TextBox()
        Me.lstCardsPlayed = New System.Windows.Forms.ListBox()
        Me.tabTurnStats = New System.Windows.Forms.TabPage()
        Me.lblCardsPlayed = New System.Windows.Forms.Label()
        Me.lblFriendly1 = New System.Windows.Forms.Label()
        Me.txtFriendlyCP = New System.Windows.Forms.TextBox()
        Me.lblFriendly2 = New System.Windows.Forms.Label()
        Me.txtFriendlyAT = New System.Windows.Forms.TextBox()
        Me.txtEnemyMDD = New System.Windows.Forms.TextBox()
        Me.lblEnemy2 = New System.Windows.Forms.Label()
        Me.lblEnemy1 = New System.Windows.Forms.Label()
        Me.txtEnemyMU = New System.Windows.Forms.TextBox()
        Me.lblMinionsDied = New System.Windows.Forms.Label()
        Me.lblAttacks = New System.Windows.Forms.Label()
        Me.txtEnemyCP = New System.Windows.Forms.TextBox()
        Me.lblResoucesUsed = New System.Windows.Forms.Label()
        Me.txtFriendlyMDD = New System.Windows.Forms.TextBox()
        Me.txtEnemyAT = New System.Windows.Forms.TextBox()
        Me.txtFriendlyMP = New System.Windows.Forms.TextBox()
        Me.txtFriendlyMU = New System.Windows.Forms.TextBox()
        Me.txtEnemyMD = New System.Windows.Forms.TextBox()
        Me.txtFriendlyHD = New System.Windows.Forms.TextBox()
        Me.lblMinionsPlayed = New System.Windows.Forms.Label()
        Me.txtEnemyCD = New System.Windows.Forms.TextBox()
        Me.lblMinionDamage = New System.Windows.Forms.Label()
        Me.lblHeroDamage = New System.Windows.Forms.Label()
        Me.txtEnemyMP = New System.Windows.Forms.TextBox()
        Me.lblCardsDrawn = New System.Windows.Forms.Label()
        Me.txtFriendlyMD = New System.Windows.Forms.TextBox()
        Me.txtEnemyHD = New System.Windows.Forms.TextBox()
        Me.txtFriendlyCD = New System.Windows.Forms.TextBox()
        Me.tabAttacks = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblAttack = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lstAttacks = New System.Windows.Forms.ListBox()
        Me.tabGameActions = New System.Windows.Forms.TabPage()
        Me.lstGameActions = New System.Windows.Forms.ListBox()
        Me.TabControl1.SuspendLayout()
        Me.tabCardsPlayed.SuspendLayout()
        Me.tabTurnStats.SuspendLayout()
        Me.tabAttacks.SuspendLayout()
        Me.tabGameActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStartLogging
        '
        Me.btnStartLogging.Location = New System.Drawing.Point(12, 370)
        Me.btnStartLogging.Name = "btnStartLogging"
        Me.btnStartLogging.Size = New System.Drawing.Size(122, 43)
        Me.btnStartLogging.TabIndex = 0
        Me.btnStartLogging.Text = "Start Logging"
        Me.btnStartLogging.UseVisualStyleBackColor = True
        '
        'btnCloseProgram
        '
        Me.btnCloseProgram.Location = New System.Drawing.Point(362, 370)
        Me.btnCloseProgram.Name = "btnCloseProgram"
        Me.btnCloseProgram.Size = New System.Drawing.Size(122, 43)
        Me.btnCloseProgram.TabIndex = 3
        Me.btnCloseProgram.Text = "Close Program"
        Me.btnCloseProgram.UseVisualStyleBackColor = True
        '
        'cbxTurnList
        '
        Me.cbxTurnList.Enabled = False
        Me.cbxTurnList.FormattingEnabled = True
        Me.cbxTurnList.Location = New System.Drawing.Point(257, 48)
        Me.cbxTurnList.Name = "cbxTurnList"
        Me.cbxTurnList.Size = New System.Drawing.Size(100, 24)
        Me.cbxTurnList.TabIndex = 5
        Me.cbxTurnList.Visible = False
        '
        'btnGetTurn
        '
        Me.btnGetTurn.Location = New System.Drawing.Point(362, 35)
        Me.btnGetTurn.Name = "btnGetTurn"
        Me.btnGetTurn.Size = New System.Drawing.Size(122, 43)
        Me.btnGetTurn.TabIndex = 6
        Me.btnGetTurn.Text = "Get Turn"
        Me.btnGetTurn.UseVisualStyleBackColor = True
        '
        'txtPlayerName
        '
        Me.txtPlayerName.Location = New System.Drawing.Point(151, 17)
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.Size = New System.Drawing.Size(100, 22)
        Me.txtPlayerName.TabIndex = 7
        '
        'lblPlayerName
        '
        Me.lblPlayerName.AutoSize = True
        Me.lblPlayerName.Location = New System.Drawing.Point(19, 20)
        Me.lblPlayerName.Name = "lblPlayerName"
        Me.lblPlayerName.Size = New System.Drawing.Size(127, 17)
        Me.lblPlayerName.TabIndex = 8
        Me.lblPlayerName.Text = "Enter Player Name"
        '
        'btnPauseLogging
        '
        Me.btnPauseLogging.Location = New System.Drawing.Point(184, 370)
        Me.btnPauseLogging.Name = "btnPauseLogging"
        Me.btnPauseLogging.Size = New System.Drawing.Size(122, 43)
        Me.btnPauseLogging.TabIndex = 9
        Me.btnPauseLogging.Text = "Pause Logging"
        Me.btnPauseLogging.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPauseLogging.UseVisualStyleBackColor = True
        '
        'cbxGameList
        '
        Me.cbxGameList.FormattingEnabled = True
        Me.cbxGameList.Location = New System.Drawing.Point(22, 48)
        Me.cbxGameList.Name = "cbxGameList"
        Me.cbxGameList.Size = New System.Drawing.Size(229, 24)
        Me.cbxGameList.TabIndex = 10
        '
        'lblCardPlayedList
        '
        Me.lblCardPlayedList.AutoSize = True
        Me.lblCardPlayedList.Location = New System.Drawing.Point(14, 286)
        Me.lblCardPlayedList.Name = "lblCardPlayedList"
        Me.lblCardPlayedList.Size = New System.Drawing.Size(92, 17)
        Me.lblCardPlayedList.TabIndex = 39
        Me.lblCardPlayedList.Text = "Cards Played"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabCardsPlayed)
        Me.TabControl1.Controls.Add(Me.tabTurnStats)
        Me.TabControl1.Controls.Add(Me.tabAttacks)
        Me.TabControl1.Controls.Add(Me.tabGameActions)
        Me.TabControl1.Location = New System.Drawing.Point(12, 83)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(481, 219)
        Me.TabControl1.TabIndex = 41
        '
        'tabCardsPlayed
        '
        Me.tabCardsPlayed.Controls.Add(Me.lblNumAttacks)
        Me.tabCardsPlayed.Controls.Add(Me.txtNumAttacks)
        Me.tabCardsPlayed.Controls.Add(Me.lblCardTarget)
        Me.tabCardsPlayed.Controls.Add(Me.txtCardTarget)
        Me.tabCardsPlayed.Controls.Add(Me.lblTurnPlayed)
        Me.tabCardsPlayed.Controls.Add(Me.txtTurnPlayed)
        Me.tabCardsPlayed.Controls.Add(Me.lstCardsPlayed)
        Me.tabCardsPlayed.Location = New System.Drawing.Point(4, 25)
        Me.tabCardsPlayed.Name = "tabCardsPlayed"
        Me.tabCardsPlayed.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCardsPlayed.Size = New System.Drawing.Size(473, 190)
        Me.tabCardsPlayed.TabIndex = 1
        Me.tabCardsPlayed.Text = "Cards Played"
        Me.tabCardsPlayed.UseVisualStyleBackColor = True
        '
        'lblNumAttacks
        '
        Me.lblNumAttacks.AutoSize = True
        Me.lblNumAttacks.Location = New System.Drawing.Point(198, 82)
        Me.lblNumAttacks.Name = "lblNumAttacks"
        Me.lblNumAttacks.Size = New System.Drawing.Size(87, 17)
        Me.lblNumAttacks.TabIndex = 19
        Me.lblNumAttacks.Text = "Num Attacks"
        Me.lblNumAttacks.Visible = False
        '
        'txtNumAttacks
        '
        Me.txtNumAttacks.Enabled = False
        Me.txtNumAttacks.Location = New System.Drawing.Point(296, 80)
        Me.txtNumAttacks.Name = "txtNumAttacks"
        Me.txtNumAttacks.Size = New System.Drawing.Size(44, 22)
        Me.txtNumAttacks.TabIndex = 18
        Me.txtNumAttacks.Visible = False
        '
        'lblCardTarget
        '
        Me.lblCardTarget.AutoSize = True
        Me.lblCardTarget.Location = New System.Drawing.Point(198, 48)
        Me.lblCardTarget.Name = "lblCardTarget"
        Me.lblCardTarget.Size = New System.Drawing.Size(84, 17)
        Me.lblCardTarget.TabIndex = 17
        Me.lblCardTarget.Text = "Card Target"
        Me.lblCardTarget.Visible = False
        '
        'txtCardTarget
        '
        Me.txtCardTarget.Enabled = False
        Me.txtCardTarget.Location = New System.Drawing.Point(296, 46)
        Me.txtCardTarget.Name = "txtCardTarget"
        Me.txtCardTarget.Size = New System.Drawing.Size(44, 22)
        Me.txtCardTarget.TabIndex = 16
        Me.txtCardTarget.Visible = False
        '
        'lblTurnPlayed
        '
        Me.lblTurnPlayed.AutoSize = True
        Me.lblTurnPlayed.Location = New System.Drawing.Point(198, 14)
        Me.lblTurnPlayed.Name = "lblTurnPlayed"
        Me.lblTurnPlayed.Size = New System.Drawing.Size(85, 17)
        Me.lblTurnPlayed.TabIndex = 15
        Me.lblTurnPlayed.Text = "Turn Played"
        Me.lblTurnPlayed.Visible = False
        '
        'txtTurnPlayed
        '
        Me.txtTurnPlayed.Enabled = False
        Me.txtTurnPlayed.Location = New System.Drawing.Point(296, 12)
        Me.txtTurnPlayed.Name = "txtTurnPlayed"
        Me.txtTurnPlayed.Size = New System.Drawing.Size(44, 22)
        Me.txtTurnPlayed.TabIndex = 14
        Me.txtTurnPlayed.Visible = False
        '
        'lstCardsPlayed
        '
        Me.lstCardsPlayed.FormattingEnabled = True
        Me.lstCardsPlayed.ItemHeight = 16
        Me.lstCardsPlayed.Location = New System.Drawing.Point(1, 3)
        Me.lstCardsPlayed.Name = "lstCardsPlayed"
        Me.lstCardsPlayed.Size = New System.Drawing.Size(190, 180)
        Me.lstCardsPlayed.TabIndex = 0
        '
        'tabTurnStats
        '
        Me.tabTurnStats.Controls.Add(Me.lblCardsPlayed)
        Me.tabTurnStats.Controls.Add(Me.lblFriendly1)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyCP)
        Me.tabTurnStats.Controls.Add(Me.lblFriendly2)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyAT)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyMDD)
        Me.tabTurnStats.Controls.Add(Me.lblEnemy2)
        Me.tabTurnStats.Controls.Add(Me.lblEnemy1)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyMU)
        Me.tabTurnStats.Controls.Add(Me.lblMinionsDied)
        Me.tabTurnStats.Controls.Add(Me.lblAttacks)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyCP)
        Me.tabTurnStats.Controls.Add(Me.lblResoucesUsed)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyMDD)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyAT)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyMP)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyMU)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyMD)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyHD)
        Me.tabTurnStats.Controls.Add(Me.lblMinionsPlayed)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyCD)
        Me.tabTurnStats.Controls.Add(Me.lblMinionDamage)
        Me.tabTurnStats.Controls.Add(Me.lblHeroDamage)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyMP)
        Me.tabTurnStats.Controls.Add(Me.lblCardsDrawn)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyMD)
        Me.tabTurnStats.Controls.Add(Me.txtEnemyHD)
        Me.tabTurnStats.Controls.Add(Me.txtFriendlyCD)
        Me.tabTurnStats.Location = New System.Drawing.Point(4, 25)
        Me.tabTurnStats.Name = "tabTurnStats"
        Me.tabTurnStats.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTurnStats.Size = New System.Drawing.Size(473, 190)
        Me.tabTurnStats.TabIndex = 0
        Me.tabTurnStats.Text = "Turn Stats"
        Me.tabTurnStats.UseVisualStyleBackColor = True
        '
        'lblCardsPlayed
        '
        Me.lblCardsPlayed.AutoSize = True
        Me.lblCardsPlayed.Location = New System.Drawing.Point(4, 35)
        Me.lblCardsPlayed.Name = "lblCardsPlayed"
        Me.lblCardsPlayed.Size = New System.Drawing.Size(92, 17)
        Me.lblCardsPlayed.TabIndex = 13
        Me.lblCardsPlayed.Text = "Cards Played"
        '
        'lblFriendly1
        '
        Me.lblFriendly1.AutoSize = True
        Me.lblFriendly1.Location = New System.Drawing.Point(99, 13)
        Me.lblFriendly1.Name = "lblFriendly1"
        Me.lblFriendly1.Size = New System.Drawing.Size(58, 17)
        Me.lblFriendly1.TabIndex = 11
        Me.lblFriendly1.Text = "Friendly"
        '
        'txtFriendlyCP
        '
        Me.txtFriendlyCP.Enabled = False
        Me.txtFriendlyCP.Location = New System.Drawing.Point(102, 33)
        Me.txtFriendlyCP.Name = "txtFriendlyCP"
        Me.txtFriendlyCP.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyCP.TabIndex = 1
        '
        'lblFriendly2
        '
        Me.lblFriendly2.AutoSize = True
        Me.lblFriendly2.Location = New System.Drawing.Point(348, 13)
        Me.lblFriendly2.Name = "lblFriendly2"
        Me.lblFriendly2.Size = New System.Drawing.Size(58, 17)
        Me.lblFriendly2.TabIndex = 25
        Me.lblFriendly2.Text = "Friendly"
        '
        'txtFriendlyAT
        '
        Me.txtFriendlyAT.Enabled = False
        Me.txtFriendlyAT.Location = New System.Drawing.Point(351, 33)
        Me.txtFriendlyAT.Name = "txtFriendlyAT"
        Me.txtFriendlyAT.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyAT.TabIndex = 24
        '
        'txtEnemyMDD
        '
        Me.txtEnemyMDD.Enabled = False
        Me.txtEnemyMDD.Location = New System.Drawing.Point(415, 128)
        Me.txtEnemyMDD.Name = "txtEnemyMDD"
        Me.txtEnemyMDD.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyMDD.TabIndex = 37
        '
        'lblEnemy2
        '
        Me.lblEnemy2.AutoSize = True
        Me.lblEnemy2.Location = New System.Drawing.Point(412, 13)
        Me.lblEnemy2.Name = "lblEnemy2"
        Me.lblEnemy2.Size = New System.Drawing.Size(51, 17)
        Me.lblEnemy2.TabIndex = 26
        Me.lblEnemy2.Text = "Enemy"
        '
        'lblEnemy1
        '
        Me.lblEnemy1.AutoSize = True
        Me.lblEnemy1.Location = New System.Drawing.Point(163, 13)
        Me.lblEnemy1.Name = "lblEnemy1"
        Me.lblEnemy1.Size = New System.Drawing.Size(51, 17)
        Me.lblEnemy1.TabIndex = 12
        Me.lblEnemy1.Text = "Enemy"
        '
        'txtEnemyMU
        '
        Me.txtEnemyMU.Enabled = False
        Me.txtEnemyMU.Location = New System.Drawing.Point(166, 128)
        Me.txtEnemyMU.Name = "txtEnemyMU"
        Me.txtEnemyMU.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyMU.TabIndex = 23
        '
        'lblMinionsDied
        '
        Me.lblMinionsDied.AutoSize = True
        Me.lblMinionsDied.Location = New System.Drawing.Point(253, 130)
        Me.lblMinionsDied.Name = "lblMinionsDied"
        Me.lblMinionsDied.Size = New System.Drawing.Size(89, 17)
        Me.lblMinionsDied.TabIndex = 36
        Me.lblMinionsDied.Text = "Minions Died"
        '
        'lblAttacks
        '
        Me.lblAttacks.AutoSize = True
        Me.lblAttacks.Location = New System.Drawing.Point(253, 35)
        Me.lblAttacks.Name = "lblAttacks"
        Me.lblAttacks.Size = New System.Drawing.Size(54, 17)
        Me.lblAttacks.TabIndex = 27
        Me.lblAttacks.Text = "Attacks"
        '
        'txtEnemyCP
        '
        Me.txtEnemyCP.Enabled = False
        Me.txtEnemyCP.Location = New System.Drawing.Point(166, 33)
        Me.txtEnemyCP.Name = "txtEnemyCP"
        Me.txtEnemyCP.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyCP.TabIndex = 14
        '
        'lblResoucesUsed
        '
        Me.lblResoucesUsed.AutoSize = True
        Me.lblResoucesUsed.Location = New System.Drawing.Point(4, 130)
        Me.lblResoucesUsed.Name = "lblResoucesUsed"
        Me.lblResoucesUsed.Size = New System.Drawing.Size(80, 17)
        Me.lblResoucesUsed.TabIndex = 22
        Me.lblResoucesUsed.Text = "Mana Used"
        '
        'txtFriendlyMDD
        '
        Me.txtFriendlyMDD.Enabled = False
        Me.txtFriendlyMDD.Location = New System.Drawing.Point(351, 128)
        Me.txtFriendlyMDD.Name = "txtFriendlyMDD"
        Me.txtFriendlyMDD.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyMDD.TabIndex = 35
        '
        'txtEnemyAT
        '
        Me.txtEnemyAT.Enabled = False
        Me.txtEnemyAT.Location = New System.Drawing.Point(415, 33)
        Me.txtEnemyAT.Name = "txtEnemyAT"
        Me.txtEnemyAT.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyAT.TabIndex = 28
        '
        'txtFriendlyMP
        '
        Me.txtFriendlyMP.Enabled = False
        Me.txtFriendlyMP.Location = New System.Drawing.Point(102, 65)
        Me.txtFriendlyMP.Name = "txtFriendlyMP"
        Me.txtFriendlyMP.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyMP.TabIndex = 15
        '
        'txtFriendlyMU
        '
        Me.txtFriendlyMU.Enabled = False
        Me.txtFriendlyMU.Location = New System.Drawing.Point(102, 128)
        Me.txtFriendlyMU.Name = "txtFriendlyMU"
        Me.txtFriendlyMU.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyMU.TabIndex = 21
        '
        'txtEnemyMD
        '
        Me.txtEnemyMD.Enabled = False
        Me.txtEnemyMD.Location = New System.Drawing.Point(415, 97)
        Me.txtEnemyMD.Name = "txtEnemyMD"
        Me.txtEnemyMD.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyMD.TabIndex = 34
        '
        'txtFriendlyHD
        '
        Me.txtFriendlyHD.Enabled = False
        Me.txtFriendlyHD.Location = New System.Drawing.Point(351, 65)
        Me.txtFriendlyHD.Name = "txtFriendlyHD"
        Me.txtFriendlyHD.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyHD.TabIndex = 29
        '
        'lblMinionsPlayed
        '
        Me.lblMinionsPlayed.AutoSize = True
        Me.lblMinionsPlayed.Location = New System.Drawing.Point(-5, 67)
        Me.lblMinionsPlayed.Name = "lblMinionsPlayed"
        Me.lblMinionsPlayed.Size = New System.Drawing.Size(103, 17)
        Me.lblMinionsPlayed.TabIndex = 16
        Me.lblMinionsPlayed.Text = "Minions Played"
        '
        'txtEnemyCD
        '
        Me.txtEnemyCD.Enabled = False
        Me.txtEnemyCD.Location = New System.Drawing.Point(166, 97)
        Me.txtEnemyCD.Name = "txtEnemyCD"
        Me.txtEnemyCD.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyCD.TabIndex = 20
        '
        'lblMinionDamage
        '
        Me.lblMinionDamage.AutoSize = True
        Me.lblMinionDamage.Location = New System.Drawing.Point(242, 99)
        Me.lblMinionDamage.Name = "lblMinionDamage"
        Me.lblMinionDamage.Size = New System.Drawing.Size(106, 17)
        Me.lblMinionDamage.TabIndex = 33
        Me.lblMinionDamage.Text = "Minion Damage"
        '
        'lblHeroDamage
        '
        Me.lblHeroDamage.AutoSize = True
        Me.lblHeroDamage.Location = New System.Drawing.Point(244, 67)
        Me.lblHeroDamage.Name = "lblHeroDamage"
        Me.lblHeroDamage.Size = New System.Drawing.Size(96, 17)
        Me.lblHeroDamage.TabIndex = 30
        Me.lblHeroDamage.Text = "Hero Damage"
        '
        'txtEnemyMP
        '
        Me.txtEnemyMP.Enabled = False
        Me.txtEnemyMP.Location = New System.Drawing.Point(166, 65)
        Me.txtEnemyMP.Name = "txtEnemyMP"
        Me.txtEnemyMP.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyMP.TabIndex = 17
        '
        'lblCardsDrawn
        '
        Me.lblCardsDrawn.AutoSize = True
        Me.lblCardsDrawn.Location = New System.Drawing.Point(4, 99)
        Me.lblCardsDrawn.Name = "lblCardsDrawn"
        Me.lblCardsDrawn.Size = New System.Drawing.Size(89, 17)
        Me.lblCardsDrawn.TabIndex = 19
        Me.lblCardsDrawn.Text = "Cards Drawn"
        '
        'txtFriendlyMD
        '
        Me.txtFriendlyMD.Enabled = False
        Me.txtFriendlyMD.Location = New System.Drawing.Point(351, 97)
        Me.txtFriendlyMD.Name = "txtFriendlyMD"
        Me.txtFriendlyMD.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyMD.TabIndex = 32
        '
        'txtEnemyHD
        '
        Me.txtEnemyHD.Enabled = False
        Me.txtEnemyHD.Location = New System.Drawing.Point(415, 65)
        Me.txtEnemyHD.Name = "txtEnemyHD"
        Me.txtEnemyHD.Size = New System.Drawing.Size(44, 22)
        Me.txtEnemyHD.TabIndex = 31
        '
        'txtFriendlyCD
        '
        Me.txtFriendlyCD.Enabled = False
        Me.txtFriendlyCD.Location = New System.Drawing.Point(102, 97)
        Me.txtFriendlyCD.Name = "txtFriendlyCD"
        Me.txtFriendlyCD.Size = New System.Drawing.Size(44, 22)
        Me.txtFriendlyCD.TabIndex = 18
        '
        'tabAttacks
        '
        Me.tabAttacks.Controls.Add(Me.Label1)
        Me.tabAttacks.Controls.Add(Me.TextBox1)
        Me.tabAttacks.Controls.Add(Me.Label2)
        Me.tabAttacks.Controls.Add(Me.TextBox2)
        Me.tabAttacks.Controls.Add(Me.lblAttack)
        Me.tabAttacks.Controls.Add(Me.TextBox3)
        Me.tabAttacks.Controls.Add(Me.lstAttacks)
        Me.tabAttacks.Location = New System.Drawing.Point(4, 25)
        Me.tabAttacks.Name = "tabAttacks"
        Me.tabAttacks.Size = New System.Drawing.Size(473, 190)
        Me.tabAttacks.TabIndex = 2
        Me.tabAttacks.Text = "Attacks"
        Me.tabAttacks.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(323, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Num Attacks"
        Me.Label1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(421, 81)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(44, 22)
        Me.TextBox1.TabIndex = 25
        Me.TextBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Card Target"
        Me.Label2.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(421, 47)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(44, 22)
        Me.TextBox2.TabIndex = 23
        Me.TextBox2.Visible = False
        '
        'lblAttack
        '
        Me.lblAttack.AutoSize = True
        Me.lblAttack.Location = New System.Drawing.Point(323, 15)
        Me.lblAttack.Name = "lblAttack"
        Me.lblAttack.Size = New System.Drawing.Size(85, 17)
        Me.lblAttack.TabIndex = 22
        Me.lblAttack.Text = "Turn Played"
        Me.lblAttack.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(421, 13)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(44, 22)
        Me.TextBox3.TabIndex = 21
        Me.TextBox3.Visible = False
        '
        'lstAttacks
        '
        Me.lstAttacks.FormattingEnabled = True
        Me.lstAttacks.ItemHeight = 16
        Me.lstAttacks.Location = New System.Drawing.Point(2, 5)
        Me.lstAttacks.Name = "lstAttacks"
        Me.lstAttacks.Size = New System.Drawing.Size(298, 180)
        Me.lstAttacks.TabIndex = 20
        '
        'tabGameActions
        '
        Me.tabGameActions.Controls.Add(Me.lstGameActions)
        Me.tabGameActions.Location = New System.Drawing.Point(4, 25)
        Me.tabGameActions.Name = "tabGameActions"
        Me.tabGameActions.Size = New System.Drawing.Size(473, 190)
        Me.tabGameActions.TabIndex = 3
        Me.tabGameActions.Text = "GameActions"
        Me.tabGameActions.UseVisualStyleBackColor = True
        '
        'lstGameActions
        '
        Me.lstGameActions.FormattingEnabled = True
        Me.lstGameActions.ItemHeight = 16
        Me.lstGameActions.Location = New System.Drawing.Point(5, 5)
        Me.lstGameActions.Name = "lstGameActions"
        Me.lstGameActions.Size = New System.Drawing.Size(298, 180)
        Me.lstGameActions.TabIndex = 21
        '
        'frmMainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 425)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblCardPlayedList)
        Me.Controls.Add(Me.cbxGameList)
        Me.Controls.Add(Me.btnPauseLogging)
        Me.Controls.Add(Me.lblPlayerName)
        Me.Controls.Add(Me.txtPlayerName)
        Me.Controls.Add(Me.btnGetTurn)
        Me.Controls.Add(Me.cbxTurnList)
        Me.Controls.Add(Me.btnCloseProgram)
        Me.Controls.Add(Me.btnStartLogging)
        Me.Name = "frmMainWindow"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.tabCardsPlayed.ResumeLayout(False)
        Me.tabCardsPlayed.PerformLayout()
        Me.tabTurnStats.ResumeLayout(False)
        Me.tabTurnStats.PerformLayout()
        Me.tabAttacks.ResumeLayout(False)
        Me.tabAttacks.PerformLayout()
        Me.tabGameActions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStartLogging As System.Windows.Forms.Button
    Friend WithEvents btnCloseProgram As System.Windows.Forms.Button
    Friend WithEvents cbxTurnList As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetTurn As System.Windows.Forms.Button
    Friend WithEvents txtPlayerName As System.Windows.Forms.TextBox
    Friend WithEvents lblPlayerName As System.Windows.Forms.Label
    Friend WithEvents btnPauseLogging As System.Windows.Forms.Button
    Friend WithEvents cbxGameList As System.Windows.Forms.ComboBox
    Friend WithEvents lblCardPlayedList As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabTurnStats As System.Windows.Forms.TabPage
    Friend WithEvents lblCardsPlayed As System.Windows.Forms.Label
    Friend WithEvents lblFriendly1 As System.Windows.Forms.Label
    Friend WithEvents txtFriendlyCP As System.Windows.Forms.TextBox
    Friend WithEvents lblFriendly2 As System.Windows.Forms.Label
    Friend WithEvents txtFriendlyAT As System.Windows.Forms.TextBox
    Friend WithEvents txtEnemyMDD As System.Windows.Forms.TextBox
    Friend WithEvents lblEnemy2 As System.Windows.Forms.Label
    Friend WithEvents lblEnemy1 As System.Windows.Forms.Label
    Friend WithEvents txtEnemyMU As System.Windows.Forms.TextBox
    Friend WithEvents lblMinionsDied As System.Windows.Forms.Label
    Friend WithEvents lblAttacks As System.Windows.Forms.Label
    Friend WithEvents txtEnemyCP As System.Windows.Forms.TextBox
    Friend WithEvents lblResoucesUsed As System.Windows.Forms.Label
    Friend WithEvents txtFriendlyMDD As System.Windows.Forms.TextBox
    Friend WithEvents txtEnemyAT As System.Windows.Forms.TextBox
    Friend WithEvents txtFriendlyMP As System.Windows.Forms.TextBox
    Friend WithEvents txtFriendlyMU As System.Windows.Forms.TextBox
    Friend WithEvents txtEnemyMD As System.Windows.Forms.TextBox
    Friend WithEvents txtFriendlyHD As System.Windows.Forms.TextBox
    Friend WithEvents lblMinionsPlayed As System.Windows.Forms.Label
    Friend WithEvents txtEnemyCD As System.Windows.Forms.TextBox
    Friend WithEvents lblMinionDamage As System.Windows.Forms.Label
    Friend WithEvents lblHeroDamage As System.Windows.Forms.Label
    Friend WithEvents txtEnemyMP As System.Windows.Forms.TextBox
    Friend WithEvents lblCardsDrawn As System.Windows.Forms.Label
    Friend WithEvents txtFriendlyMD As System.Windows.Forms.TextBox
    Friend WithEvents txtEnemyHD As System.Windows.Forms.TextBox
    Friend WithEvents txtFriendlyCD As System.Windows.Forms.TextBox
    Friend WithEvents tabCardsPlayed As System.Windows.Forms.TabPage
    Friend WithEvents lstCardsPlayed As System.Windows.Forms.ListBox
    Friend WithEvents lblTurnPlayed As System.Windows.Forms.Label
    Friend WithEvents txtTurnPlayed As System.Windows.Forms.TextBox
    Friend WithEvents lblCardTarget As System.Windows.Forms.Label
    Friend WithEvents txtCardTarget As System.Windows.Forms.TextBox
    Friend WithEvents lblNumAttacks As System.Windows.Forms.Label
    Friend WithEvents txtNumAttacks As System.Windows.Forms.TextBox
    Friend WithEvents tabAttacks As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lblAttack As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents lstAttacks As System.Windows.Forms.ListBox
    Friend WithEvents tabGameActions As System.Windows.Forms.TabPage
    Friend WithEvents lstGameActions As System.Windows.Forms.ListBox

End Class
