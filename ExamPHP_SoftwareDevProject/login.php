<?php
    session_start();
	  require_once "configuration.php";
    $_SESSION['myUser']= $_GET["username"];
    $myUser = $_SESSION['myUser'];
    global $connection;


    $str = "SELECT count(*) as total from project";
    //  echo $str;
    $result = mysqli_query($connection, $str);
    $data=$result->fetch_assoc();
    $_SESSION['oldprojectcount']= $data['total'];

    ?>
 <html>
 <body>

     Welcome <?php echo $myUser; ?><br>
     <br>
     <br>

     <div>
        <form method="get" action="checkUpdates.php">
            <button>Check updates</button>
        </form>
        <p>All projects: </p>
     <?php $myUser =$_SESSION['myUser'];
        $str = "SELECT * from project";
        //  echo $str;
        $result = mysqli_query($connection, $str);

        //echo "<html><body>";
        echo "<table border='1'><tr><th>Name</th><th>Description</th><th>Members</th></tr>";
        while($row = mysqli_fetch_array($result) ){
            echo "<tr>";
            echo "<td>" . $row['name'] . "</td>";
            echo "<td>" . $row['description'] . "</td>";
            echo "<td>" . $row['members'] . "</td>";
            echo "</tr>";
        }
        echo "</table>";
        //echo "</body></html>";
        ?>
     </div>

    <div>
     <p>Your Projects: </p>
     
<?php $myUser =$_SESSION['myUser'];
$str = "SELECT * from project where members like '%".$myUser."%'";
//  echo $str;
$result = mysqli_query($connection, $str);

//echo "<html><body>";
echo "<table border='1'><tr><th>Name</th><th>Description</th><th>Members</th></tr>";
while($row = mysqli_fetch_array($result) ){
    echo "<tr>";
    echo "<td>" . $row['name'] . "</td>";
    echo "<td>" . $row['description'] . "</td>";
    echo "<td>" . $row['members'] . "</td>";
    echo "</tr>";
}
echo "</table>";
//echo "</body></html>";
mysqli_close($connection);
?>

<div>
<br><br>


     <button onclick="window.location.href='filterSkills.html'"> Filter devs by skills</button>
     <br>
     <br>
     <form action="addDeveloper.php" method="get">
            Add developer to project:<br>
             <input type="text" placeholder="developer" name="developer" required><br>
             <input type="text" placeholder="project" name="project" required><br>
            <input type="submit">
</form>
     
    

 </body>

 </html>