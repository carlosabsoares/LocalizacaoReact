import { React } from "react";
import { GoogleMap, useJsApiLoader, Marker } from '@react-google-maps/api';
import './Mapa.css';

export const MapView = ({latitude, longitude, placa}) => {
  console.log("🚀 ~ MapView ~ placa:", placa)
  const {isLoaded} = useJsApiLoader({
    id: "google-map-script",
    googleMapsApiKey:"AIzaSyDNsd4dqqu9VQrsf9roFPSxFTFYE2zgWyY"
  }) ; 


  
const position ={
  lat: latitude,
  lng: longitude
}
  return ( 
    <div className="map">
    {isLoaded ? (
    <GoogleMap
      mapContainerStyle={{width: '100%', height: '100%'}}
      center={position}
      zoom={15}
    >
      <Marker 
        position={position} 
        options={{
          label:{
            text: `Placa: ${placa}`  ,
            className:"mapMarker",
          }
        }}
        />
    </GoogleMap>
) : <></>
}
</div>
)}

export default MapView