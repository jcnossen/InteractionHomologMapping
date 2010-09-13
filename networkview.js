var vis;

function menuGotoStringURL(evt) {
	// Get the right-clicked node:
	var node = evt.target;

	if (node.data.string_id) {
		var url = 'http://string-db.org/version_8_3/newstring_cgi/show_network_section.pl?all_channels_on=1' +
			'&interactive=yes&network_flavor=evidence&targetmode=proteins&identifier=' + node.data.string_id;

		window.open(url);
	}
}

function menuGotoBiobrickPage(evt) {
	// Get the right-clicked node:
	var node = evt.target;

	if (node.data.biobrick)
		window.open('http://partsregistry.org/wiki/index.php?title=Part:'+node.data.biobrick);
}


function initializeViewer(networkData) {
	// 2. Add a context menu item any time after the network is ready:
	vis.ready(function () {
		vis.addContextMenuItem("Go to STRING page", "nodes", menuGotoStringURL);
		vis.addContextMenuItem("Go to Biobrick page (if any)", "nodes", menuGotoBiobrickPage);
	});
	vis.draw({ network: networkData });
}

function loadnetwork(url) {
	// id of Cytoscape Web container div
	var div_id = "cytoscapeweb";

	// initialization options
	var options = {
		// where you have the Cytoscape Web SWF
		swfPath: "CytoscapeWeb/swf/CytoscapeWeb",
		// where you have the Flash installer SWF
		flashInstallerPath: "CytoscapeWeb/swf/playerProductInstall"
	};

	vis = new org.cytoscapeweb.Visualization(div_id, options);

	$.ajax({
		url: url,
		dataType: 'text',
		success: initializeViewer
	});
}
