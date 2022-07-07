<?php
// CONNECTIONS =========================================================
$host = "sql354.main-hosting.eu"; //put your host here
$user = "u630397682_gljf"; //in general is root
$password = "Cbhs1881"; //use your password here
$dbname = "u630397682_gljf"; //your database


$conn = new mysqli($host, $user, $password, $dbname);

if ($conn->connect_error) {
	die("Connection failed: " . $conn->connect_error);
 }
 //echo "<h1>Connected successfully</h1>";

$login_username = $_GET['u'];
$login_password = $_GET['p'];

/*
$login_username = "testuser";
$login_password = "1234";
*/
$login_pw_hash = md5($login_password);
 $sql = "SELECT * FROM scores WHERE name ='" . $login_username ."' AND password='". $login_pw_hash . "'";
// echo $sql;
$result = $conn->query($sql);
//$result = mysqli_query($conn, $sql);
//echo "<br>";
//echo $result . "<br>";

if ($result->num_rows > 0) {
	// output data of each row
	while($row = $result->fetch_assoc()) {
	  echo "SUCCESS";
	}
 } else {
	echo "FAIL";
 }

 //echo "<h3>end</h3>";

 $conn->close();
?>