<?php
// CONNECTIONS =========================================================
$host = "localhost"; //put your host here
$user = "u630397682_gljf"; //in general is root
$password = "Cbhs1881"; //use your password here
$dbname = "u630397682_gljf"; //your database

//$conn = new mysqli($host, $user, $password);

//mysql_connect($host, $user, $password) or die("Cant connect into database");
//mysql_select_db($dbname)or die("Cant connect into database");
// =============================================================================
// PROTECT AGAINST SQL INJECTION and CONVERT PASSWORD INTO MD5 formats

try 
{
	$dbh = new PDO('mysql:host='. $host .';dbname='. $dbname, 
         $user, $password);
} 
catch(PDOException $e) 
{
	echo '<h1>An error has occurred.</h1><pre>', $e->getMessage()
            ,'</pre>';
}
 
$sth = $dbh->query('SELECT * FROM scores ORDER BY score DESC LIMIT 5');
$sth->setFetchMode(PDO::FETCH_ASSOC);
 
$result = $sth->fetchAll();
 
if (count($result) > 0) 
{
	foreach($result as $r) 
	{
		echo $r['name'], "\n _";
		echo $r['score'], "\n _";
	}
}
?>