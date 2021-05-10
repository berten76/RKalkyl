import React from 'react'
import { Button, Header, Icon, Modal } from 'semantic-ui-react'

interface Props {
  setResponse: (deleteMeal: boolean) => void;
}

export default function DeleteModal({ setResponse }: Props) {
  const [open, setOpen] = React.useState(false)


  return (
    <Modal
      open={open}
      trigger={<Button content='Delete' color='red' />}
      onClose={() => setOpen(false)}
      onOpen={() => setOpen(true)}
    >
      <Header icon='delete' content='Delete' />
      <Modal.Content>
        <p>
          Are you sure you want to delete this meal?
        </p>
      </Modal.Content>
      <Modal.Actions>
        <Button color='red' onClick={() => HandleClick(true)}>
          <Icon name='remove' /> Yes
        </Button>
        <Button color='green' onClick={() => HandleClick(false)}>
          <Icon name='checkmark' /> No
        </Button>
      </Modal.Actions>
    </Modal>
  )

  function HandleClick(deleteMeal: boolean) {
    setOpen(false);
    setResponse(deleteMeal);
  }

}