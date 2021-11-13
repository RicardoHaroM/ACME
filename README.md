<div class="editormd-preview" style="display: block; width: 73px; top: 466px; height: 115px; position: absolute;">
    <div class="markdown-body editormd-preview-container" previewcontainer="true" style="padding: 20px;">
        <h1 id="h1--acme-company-exercise"><a name="🏢 ACME company exercise" class="reference-link"></a><span
                class="header-link octicon octicon-link"></span>🏢 ACME company exercise</h1>
        <h3 id="h3-exercise-description"><a name="Exercise description" class="reference-link"></a><span
                class="header-link octicon octicon-link"></span>Exercise description</h3>
        <p>The company ACME offers their employees the flexibility to work the hours they want. But due to some external
            circumstances they need to know what employees have been at the office within the same time frame</p>
        <p>The goal of this exercise is to output a table containing pairs of employees and how often they have
            coincided in the office.</p>
        <h3 id="h3-solution-explanation"><a name="Solution explanation" class="reference-link"></a><span
                class="header-link octicon octicon-link"></span>Solution explanation</h3>
        <p>The approach of this solution is to implement an optimal algorithm using data structures such as hash tables
            and binary trees to be able to leave behind a brute force algorithm</p>
        <p>The solution is divided in two classes, the first one is ACME which is in charge of entering the data and
            printing the results. The second class is Node this class is used to create a binary tree in which we
            compare and store the schedules</p>
        <p>Once the schedule in which an employee works on a certain day is entered in the program, it goes to a hash
            table that contains binary trees according to the day and is entered in the corresponding tree, in case it
            does not exist, it is created. In the binary tree all the nodes are ordered so that the entered data will be
            compared only with the necessary nodes and in case the schedules coincide, it will be increased in the
            results hash table, when the data has been entered this table is printed with the results.</p>
        <h3 id="h3-how-to-run-the-program"><a name="How to run the program" class="reference-link"></a><span
                class="header-link octicon octicon-link"></span>How to run the program</h3>
        <p>To run the program we have to open the cmd and go to the code folder and then we use the following command:
        </p>
        <p><code>C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe Program.cs</code></p>
        <p>This creates the executable and now to run it we enter:</p>
        <p><code>Program.cs</code></p>
        <h3 id="h3-how-to-change-the-input-data"><a name="How to change the input data" class="reference-link"></a><span
                class="header-link octicon octicon-link"></span>How to change or see the input data</h3>
        <p>If you want to change or see the input data, you can go to the test folder where there is a .txt file where you can
            change the data</p>
        <p>The input data is structured as follows:</p>
        <p><code>2</code> —&gt; Number of employees in the data
            set<br><code>RENE=MO10:15-12:00,TU10:00-12:00,TH13:00-13:15,SA14:00-18:00,SU20:00-21:00</code>
            —&gt; Employee name =
            DayStartHour-EndHour<br><code>ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00</code>
            <br><code>.</code>—&gt; It is used to finish the execution
        </p>
    </div>
</div>
