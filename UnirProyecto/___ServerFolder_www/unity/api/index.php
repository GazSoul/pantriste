<?php 
	//include_once("db.php");

  	$host   = "mysql:host=127.0.0.1;dbname=pan_triste_bbdd";
	$user   = "root";
	$pass   = "";
	// $option = array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8");

/* 	$servername = "localhost";
	$username = "root";
	$password = "";
	$db = "pan_triste_bbdd"; */

	try{
		$con = new PDO($host,$user, $pass);
		$con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}catch(PDOException $e){ echo $e.getMessage(); }

	if (isset($_POST["username"]) && !empty($_POST["username"]) && 
		isset($_POST["password"]) && !empty($_POST["password"])){

		Login($_POST["username"], $_POST["password"]);
	}

	function Login($username, $password){
		GLOBAL $con;

		$sql = "SELECT name_usr,pass_usr FROM usuarios WHERE name_usr=? AND pass_usr=?";
		$st=$con->prepare($sql);

		$st->execute(array($username, sha1($password)));//encrypt password
		$all=$st->fetchAll();
		if (count($all) == 1){
			echo "SERVER: ID#".$all[0]["pkid"]." - ".$all[0]["name_usr"];
			exit();
		}

		//if username or password are empty strings
		echo "SERVER: error, invalid username or password";
		exit();
	}

	//if username or password is null (not set)
	echo "SERVER: error, enter a valid username & password";

	//exit():  means end server connection (don't execute the rest)
?>